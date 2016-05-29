using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MethodImmo.Services.ViewModels
{
    /// <summary>
    /// Summary description for Info
    /// </summary>
    public class Info : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}