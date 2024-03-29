﻿#region Using

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Xml;
using System.Net;
using BlogEngine.Core;

#endregion

namespace BlogEngine.Core.Web.HttpHandlers
{
	/// <summary>
	/// Implements a custom handler to synchronously process HTTP Web requests for a syndication feed.
	/// </summary>
	/// <remarks>
	/// This handler can generate syndication feeds in a variety of formats and filtering 
	/// options based on the query string parmaeters provided.
	/// </remarks>
	/// <seealso cref="IHttpHandler"/>
	/// <seealso cref="SyndicationGenerator"/>
	public class SyndicationHandler : IHttpHandler
	{

		#region IHttpHandler Members

		/// <summary>
		/// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"></see> instance.
		/// </summary>
		/// <returns>true if the <see cref="T:System.Web.IHttpHandler"></see> instance is reusable; otherwise, false.</returns>
		public bool IsReusable
		{
			get { return false; }
		}

		/// <summary>
		/// Enables processing of HTTP Web requests by a custom HttpHandler that implements 
		/// the <see cref="T:System.Web.IHttpHandler"></see> interface.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"></see> object that provides references 
		/// to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.
		/// </param>
        public void ProcessRequest(HttpContext context)
        {
            string title = RetrieveTitle(context);
            SyndicationFormat format = RetrieveFormat(context);
            List<IPublishable> list = GenerateItemList(context);
            list = CleanList(list);

            if (string.IsNullOrEmpty(context.Request.QueryString["post"]))
            {
                // Shorten the list to the number of posts stated in the settings, except for the comment feed.
                int max = Math.Min(BlogSettings.Instance.PostsPerFeed, list.Count);
                list = list.FindAll(delegate(IPublishable item)
                {
                    return item.IsVisible == true;
                });

                list = list.GetRange(0, max);
            }

            SetHeaderInformation(context, list, format);

            if (BlogSettings.Instance.EnableHttpCompression)
                HttpModules.CompressionModule.CompressResponse(context);

            SyndicationGenerator generator = new SyndicationGenerator(BlogSettings.Instance, Category.Categories);
            generator.WriteFeed(format, context.Response.OutputStream, list, title);
        }

		#endregion

		#region Retrieve feed items

		/// <summary>
		/// Generates the list of feed items based on the URL.
		/// </summary>
		private static List<IPublishable> GenerateItemList(HttpContext context)
		{
			if (!string.IsNullOrEmpty(context.Request.QueryString["category"]))
			{
				// All posts in the specified category
				Guid categoryId = new Guid(context.Request.QueryString["category"]);
				return Post.GetPostsByCategory(categoryId).ConvertAll(new Converter<Post, IPublishable>(ConvertToIPublishable));
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["author"]))
			{
				// All posts by the specified author
				string author = context.Request.QueryString["author"];
				return Post.GetPostsByAuthor(author).ConvertAll(new Converter<Post, IPublishable>(ConvertToIPublishable));
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["post"]))
			{
				// All comments of the specified post
				Post post = Post.GetPost(new Guid(context.Request.QueryString["post"]));
				return post.Comments.ConvertAll(new Converter<Comment, IPublishable>(ConvertToIPublishable));
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["comments"]))
			{
				// The recent comments added to any post.
				return RecentComments();
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["q"]))
			{
				// Searches posts and pages
				return Search.Hits(context.Request.QueryString["q"], false);
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["apml"]))
			{
				// Finds matches to  an APML file in both posts and pages
				try
				{
					using (WebClient client = new WebClient())
					{
						client.Credentials = CredentialCache.DefaultNetworkCredentials;
						client.Encoding = Encoding.Default;
						using (System.IO.Stream stream = client.OpenRead(context.Request.QueryString["apml"]))
						{
							XmlDocument doc = new XmlDocument();
							doc.Load(stream);
							List<IPublishable> list = Search.ApmlMatches(doc, 30);
							list.Sort(delegate(IPublishable i1, IPublishable i2) { return i2.DateCreated.CompareTo(i1.DateCreated); });
							return list;
						}
					}
				}
				catch (Exception ex)
				{
					context.Response.Clear();
					context.Response.Write(ex.Message);
					context.Response.ContentType = "text/plain";
					context.Response.AppendHeader("Content-Disposition", "inline; filename=\"error.txt\"");
					context.Response.End();
				}
			}

			// The latest posts
			return Post.Posts.ConvertAll(new Converter<Post, IPublishable>(ConvertToIPublishable));
		}

		private static List<IPublishable> CleanList(List<IPublishable> list)
		{
			return list.FindAll(delegate(IPublishable item)
			{
				return item.IsVisible;
			});
		}

		/// <summary>
		/// Creates a list of the most recent comments
		/// </summary>
		private static List<IPublishable> RecentComments()
		{
			List<Comment> temp = new List<Comment>();

			foreach (Post post in Post.Posts)
			{
				foreach (Comment comment in post.ApprovedComments)
				{
					temp.Add(comment);
				}
			}

			temp.Sort();
			temp.Reverse();
			List<Comment> list = new List<Comment>();

			foreach (Comment comment in temp)
			{
				list.Add(comment);
			}

			return list.ConvertAll(new Converter<Comment, IPublishable>(ConvertToIPublishable));
		}

		#endregion

		#region Helper methods

		/// <summary>
		/// A converter delegate used for converting Results to Posts.
		/// </summary>
		private static IPublishable ConvertToIPublishable(IPublishable item)
		{
			return item;
		}

		/// <summary>
		/// Retrieves the syndication format from the urL parameters.
		/// </summary>
		private static SyndicationFormat RetrieveFormat(HttpContext context)
		{
			string query = context.Request.QueryString["format"];
			string format = BlogSettings.Instance.SyndicationFormat;
			if (!string.IsNullOrEmpty(query))
			{
				format = context.Request.QueryString["format"];
			}

			try
			{
				return (SyndicationFormat)Enum.Parse(typeof(SyndicationFormat), format, true);
			}
			catch (ArgumentException)
			{
				return SyndicationFormat.None;
			}
		}

		private static string RetrieveTitle(HttpContext context)
		{
			string title = BlogSettings.Instance.Name;
			string subTitle = null;

			if (!string.IsNullOrEmpty(context.Request.QueryString["category"]))
			{
				if (context.Request.QueryString["category"].Length != 36)
					StopServing(context);

				Guid categoryId = new Guid(context.Request.QueryString["category"]);
				Category currentCategory = Category.GetCategory(categoryId);
				if (currentCategory == null)
				{
					StopServing(context);
				}
				subTitle = currentCategory.Title;
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["author"]))
			{
				subTitle = context.Request.QueryString["author"];
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["post"]))
			{
				if (context.Request.QueryString["post"].Length != 36)
					StopServing(context);

				Post post = Post.GetPost(new Guid(context.Request.QueryString["post"]));
				if (post == null)
				{
					StopServing(context);
				}
				subTitle = post.Title;
			}

			if (!string.IsNullOrEmpty(context.Request.QueryString["comments"]))
			{
				subTitle = "Comments";
			}

			if (subTitle != null)
				return title + " - " + subTitle;

			return title;
		}

		private static void StopServing(HttpContext context)
		{
			context.Response.Clear();
			context.Response.StatusCode = 404;
			context.Response.End();
		}

		/// <summary>
		/// Sets the response header information.
		/// </summary>
		/// <param name="context">An <see cref="HttpContext"/> object that provides references to the intrinsic server objects (for example, <b>Request</b>, <b>Response</b>, <b>Session</b>, and <b>Server</b>) used to service HTTP requests.</param>
		/// <param name="items">The collection of <see cref="IPublishable"/> instances used when setting the response header details.</param>
		/// <param name="format">The format of the syndication feed being generated.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="context"/> is a null reference (Nothing in Visual Basic) -or- the <paramref name="posts"/> is a null reference (Nothing in Visual Basic).</exception>
		private static void SetHeaderInformation(HttpContext context, List<IPublishable> items, SyndicationFormat format)
		{
            DateTime lastModified = new DateTime(1900, 1, 3); // don't use DateTime.MinValue here, as Mono doesn't like it
			foreach (IPublishable item in items)
			{
				if (item.DateModified.AddHours(-BlogSettings.Instance.Timezone) > lastModified)
					lastModified = item.DateModified.AddHours(-BlogSettings.Instance.Timezone);
			}

			switch (format)
			{
				case SyndicationFormat.Atom:
					context.Response.ContentType = "application/atom+xml";
					context.Response.AppendHeader("Content-Disposition", "inline; filename=atom.xml");
					break;

				case SyndicationFormat.Rss:
					context.Response.ContentType = "application/rss+xml";
					context.Response.AppendHeader("Content-Disposition", "inline; filename=rss.xml");
					break;
			}

            if (Utils.SetConditionalGetHeaders(lastModified)) 
                context.Response.End();
            
		}

		#endregion

	}
}
