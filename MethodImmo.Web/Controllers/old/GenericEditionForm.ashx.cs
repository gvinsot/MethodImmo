using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace MethodImmo.Services.Views
{
    /// <summary>
    /// Summary description for GenericEditionForm
    /// </summary>
    public class GenericEditionForm : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            object root = new AdressePostale();
            if (context.Request.QueryString["type"]!=null)
            {
                Type type = Type.GetType("MethodImmo.DAL." + context.Request.QueryString["type"] + ", MethodImmo.DAL");
                root = type.GetConstructor(Type.EmptyTypes).Invoke(null);
            }
            int deep = 0;

            ObjectTools.ForEachMemberRecursive(root, null, null, (val, parent, memberInfo, ctx) =>
               {
                   PropertyInfo prop = memberInfo as PropertyInfo;
                   FieldInfo field = memberInfo as FieldInfo;
                   Type valueType = prop != null ? prop.PropertyType : field != null ? field.FieldType : val == null ? null : val.GetType();
                   

                   if (deep >= 4)
                       return false;
                   if (!ObjectTools.IsPrimitiveType(valueType))
                   {
                       deep++;
                       context.Response.Output.WriteLine("<div>");
                   }
                   return true;
               }, (val, parent, memberInfo, ctx) =>
               {
                   if (val == null)
                   {
                       context.Response.Output.WriteLine(@"<div class=""form-group"">");
                       context.Response.Output.WriteLine($"<label class=\"control-label col-sm-2\" for=\"\">{memberInfo.Name}</label>");
                       context.Response.Output.WriteLine(@"<div class=""col-sm-10"">");
                       context.Response.Output.WriteLine(@"<input type=""email"" class=""form-control"" id=""email"" placeholder=""Enter email"">");
                       context.Response.Output.WriteLine("</div>\n</div>");
                   }
                   else
                   {
                       Type valueType = val.GetType();
                       if (ObjectTools.IsPrimitiveType(valueType))
                       {
                           context.Response.Output.WriteLine(@"<div class=""form-group"">");
                           context.Response.Output.WriteLine($"<label class=\"control-label col-sm-2\" for=\"\">{memberInfo.Name}</label>");
                           context.Response.Output.WriteLine(@"<div class=""col-sm-10"">");
                           context.Response.Output.WriteLine(@"<input type=""email"" class=""form-control"" id=""email"" placeholder=""Enter email"">");
                           context.Response.Output.WriteLine("</div>\n</div>");
                       }
                       else
                       {

                       }
                   }             
               }, (val, parent, memberInfo, ctx) =>
               {
                   PropertyInfo prop = memberInfo as PropertyInfo;
                   FieldInfo field = memberInfo as FieldInfo;
                   Type valueType = prop != null ? prop.PropertyType : field != null ? field.FieldType : val == null ? null : val.GetType();

                   if (!ObjectTools.IsPrimitiveType(valueType))
                   {
                       deep--;
                       context.Response.Output.WriteLine("</div>");
                   }
                   
               });
            
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