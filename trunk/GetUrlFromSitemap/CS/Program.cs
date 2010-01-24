using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string sitemap = client.DownloadString("http://code2code.info/sitemap.xml");
            XElement element = XElement.Parse(sitemap);
            var e = from i in element.Elements()
                    select i.FirstNode;
            foreach (XNode item in e)
            {
                string url = ((XElement)(item)).Value;
                Console.WriteLine(url);
            }
            Console.Read();
        }
    }
}
