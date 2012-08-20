using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Text;
using CommonClass;



namespace PGFine.Ctrl
{
    public partial class CtrlYahooOnline : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUser1 =ConfigurationManager.AppSettings["UserOnline1"];
            string strImagesOnline1 = ConfigurationManager.AppSettings["ImagesOnline1"];
            string strImagesOff1 = ConfigurationManager.AppSettings["ImagesOff1"];
            hplinkOnline1.NavigateUrl = string.Format("ymsgr:sendIM?{0}", strUser1);
            if (Checkonline(strUser1) == "0")
            {
                imgOnline.ImageUrl = ResolveUrl(strImagesOff1);
            }
            else if (Checkonline(strUser1) == "1")
            {
                imgOnline.ImageUrl = ResolveUrl(strImagesOnline1);
            }  
         
            //user2            
            string strUser2 = ConfigurationManager.AppSettings["UserOnline2"];
            string strImagesOnline2 = ConfigurationManager.AppSettings["ImagesOnline2"];
            string strImagesOff2 = ConfigurationManager.AppSettings["ImagesOff2"];

            hplinkOnline2.NavigateUrl = string.Format("ymsgr:sendIM?{0}", strUser2);
            if (Checkonline(strUser2) == "0")
            {
                imgOnline1.ImageUrl = ResolveUrl(strImagesOff2);
            }
            else if (Checkonline(strUser2) == "1")
            {
                imgOnline1.ImageUrl = ResolveUrl(strImagesOnline2);
            }       

            //Load ngon ngu
            lbCaptionOnline.Text = Location.GetLanguageTag("Online").ToString();
        }

        private string Checkonline(string strNick)
        {
            string sHtml = string.Empty;
            try
            {
                string strPart = String.Format("http://opi.yahoo.com/online?u={0}&m=t", strNick);
                sHtml = HttpUtility.HtmlDecode(GetHtmlFromInternet(strPart, false));
                if (sHtml.IndexOf("NOT ONLINE") > 0)
                    return "0";
                return "1";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetHtmlFromInternet(string sURI, bool bUnicode)
        {
            System.Net.WebRequest req = HttpWebRequest.Create(sURI);// WebRequest.Create(sURI);
            string sProxy = "";//System.Configuration.ConfigurationSettings.AppSettings("proxy");
            int iPort = 0;
            string sUserName = "";//System.Configuration.ConfigurationSettings.AppSettings("usrname");
            string sPwd = "";//System.Configuration.ConfigurationSettings.AppSettings("pwd");
            try
            {
                iPort = 8080;//'CInt(System.Configuration.ConfigurationSettings.AppSettings("port"))
            }
            catch
            {
                iPort = 8080;
            }

            if (sProxy != "" && iPort > 0)
            {
                req.Proxy = new System.Net.WebProxy(sProxy, iPort);
                if (sUserName != "")
                {
                    req.Proxy.Credentials = new System.Net.NetworkCredential(sUserName, sPwd);
                }
            }

            WebResponse response = req.GetResponse();
            //System.Net.HttpWebResponse reader = response.GetResponseStream;
            System.IO.StreamReader bs;
            Encoding encode;

            try
            {
                if (bUnicode == true)
                    encode = Encoding.UTF8;
                else
                    encode = Encoding.GetEncoding(1252);
                bs = new System.IO.StreamReader(response.GetResponseStream(), encode);
                string sHTML = string.Empty;
                sHTML = bs.ReadToEnd();
                bs.Close();
                response.Close();

                return sHTML;
            }
            catch
            {
                return string.Empty;
            }
        }




    }
}