using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.IO;
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