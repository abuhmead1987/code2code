using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allUrls = new List<string>();
            WebClient client = new WebClient();
            string content = client.DownloadString("http://code2code.info");
            string pattern = @"(?i)(?s)<a[^>]+?href=""?(?<url>[^""]+)""?>(?<innerHtml>.+?)</a\s*>";
            MatchCollection result = Regex.Matches(content, pattern);

            foreach (Match match in result)
            {
                string url = match.Groups["url"].Value;

                if (url.IndexOf("http://") != -1)
                {
                    allUrls.Add(url);
                }
                Console.WriteLine(url);
            }
            Console.Read();
        }
    }
}
