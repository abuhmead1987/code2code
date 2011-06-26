<%@ WebHandler Language="C#" Class="KeepSessionAlive" %>

using System;
using System.Web;

public class KeepSessionAlive : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Session is alive");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}