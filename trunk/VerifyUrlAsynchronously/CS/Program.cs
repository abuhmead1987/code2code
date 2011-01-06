using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace CS
{
    public class Program
    {
        ///reference: http://stevesmithblog.com/blog/verify-a-list-of-urls-in-c-asynchronously/
        public static void Main(string[] args)
        {
            List<string> urls = new List<string>() { "http://code2code.info", "http://vinaIphone.com", "http://vinaIphone.net", "http://localhost" };
            Parallel.ForEach(urls, l => VerifyUrl(l));
            Console.Read();
        }

        public static void VerifyUrl(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "HEAD";
            NetworkCredential networkCredential = new NetworkCredential("nguyen.quach", "1111111");

            IWebProxy proxyies = WebRequest.GetSystemWebProxy();
            proxyies.Credentials = CredentialCache.DefaultCredentials;

            var response = request.GetResponse() as HttpWebResponse;
            request.Proxy = proxyies;
            request.Credentials = networkCredential;

            if ((response.StatusCode == HttpStatusCode.OK))
            {
                Console.WriteLine(string.Format("{0} worked!",url));
            }
            else
            {
                Console.WriteLine(string.Format("{0} does not worked!", url));
            }
        }
    }
}
