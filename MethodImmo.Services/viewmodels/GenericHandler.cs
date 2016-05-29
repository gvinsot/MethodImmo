using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MethodImmo.Services.ViewModels
{
    /// <summary>
    /// Summary description for Immeuble
    /// </summary>
    public abstract class GenericHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "application/json";

                string result = string.Empty;
                long objectId = -1;

                switch (context.Request.HttpMethod)
                {
                    case "GET": //Return list
                        using (var ctxt = new MethodImmoContext())
                        {
                            result = Serialize(Get(ctxt, context.Request.QueryString));
                        }
                        
                        break;


                    case "POST": //CREATE OR REPLACE
                        string postSerialized = "";
                        using (var sr = new StreamReader(context.Request.InputStream))
                        {
                            postSerialized = sr.ReadToEnd();
                        }
                        result = JsonSerializationTool<ResultObject>.SerializeAllTree(Post(postSerialized, context.Request.QueryString));
                        break;

                    case "PUT":
                        string serialized = "";
                        using (var sr = new StreamReader(context.Request.InputStream))
                        {
                            serialized = sr.ReadToEnd();

                        }
                        var resultObject = Put(serialized, context.Request.QueryString);

                        result = JsonSerializationTool<ResultObject>.SerializeAllTree(resultObject);
                        break;


                    case "DELETE":
                        if (!long.TryParse(context.Request.QueryString["id"], out objectId))
                        {
                            //ERROR
                        }
                        var deleteResultObject = Delete(context.Request.QueryString);
                        result = JsonSerializationTool<ResultObject>.SerializeAllTree(deleteResultObject);
                        break;
                }

                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.ToString());
            }
        }

        public abstract object Get(MethodImmoContext context,NameValueCollection parameters);
        
        // = CREATE / REPLACE
        public virtual ResultObject Post(string receivedJson, NameValueCollection parameters)
        {
            return new ResultObject(HttpStatusCode.NotImplemented, "Create feature not available for this object", (new StackTrace()).ToString());
        }

        // = UPDATE
        public virtual ResultObject Put(string receivedJson, NameValueCollection parameters)
        {
            return new ResultObject(HttpStatusCode.NotImplemented, "Update feature not available for this object", (new StackTrace()).ToString());
        }

        public virtual ResultObject Delete(NameValueCollection parameters)
        {
            return new ResultObject(HttpStatusCode.NotImplemented, "Delete feature not available for this object", (new StackTrace()).ToString());
        }


        public virtual string Serialize(object toSerialize)
        {
            string result = JsonSerializationTool<object>.SerializeRootSinglesAndIds(toSerialize,null,null,(object val, object parent,MemberInfo info,object context)=>
            {
                PropertyInfo property = info as PropertyInfo;
                FieldInfo field = info as FieldInfo;
                if (property != null)
                {
                    return ObjectTools.IsPrimitiveType(property.PropertyType) || property.PropertyType.Namespace.StartsWith("System.Collection") || property.PropertyType.Namespace.StartsWith("System.Data.Entity.DynamicProxies");
                }
                else if (field != null)
                {
                    return ObjectTools.IsPrimitiveType(field.FieldType) ||  field.FieldType.Namespace.StartsWith("System.Data.Entity.DynamicProxies");
                }
                return false;
            });
            return result;
        }


        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}