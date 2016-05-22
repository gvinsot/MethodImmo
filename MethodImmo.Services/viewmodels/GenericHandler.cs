using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MethodImmo.Services.ViewModels
{
    /// <summary>
    /// Summary description for Immeuble
    /// </summary>
    public class GenericHandler<T> : IHttpHandler where T:class
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
                        if (long.TryParse(context.Request.QueryString["id"], out objectId))
                        {
                            result = Serialize(Get(objectId));
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            var items = Get();
                            sb.Append("[");
                            foreach (var item in items)
                            {
                                sb.Append(Serialize(item));
                                sb.Append(",");
                            }
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("]");
                            result = sb.ToString();
                        }
                        break;


                    case "POST": //CREATE OR REPLACE
                        string postSerialized = "";
                        using (var sr = new StreamReader(context.Request.InputStream))
                        {
                            postSerialized = sr.ReadToEnd();

                        }
                        T resultTObject = JsonSerializationTool<T>.Deserialize(postSerialized);
                        result = JsonSerializationTool<ResultObject>.Serialize(Post(resultTObject));
                        break;

                    case "PUT":
                        if (!long.TryParse(context.Request.QueryString["id"], out objectId))
                        {
                            //ERROR
                        }

                        string serialized = "";
                        using (var sr = new StreamReader(context.Request.InputStream))
                        {
                            serialized = sr.ReadToEnd();

                        }
                        var resultObject = Put(objectId, serialized);

                        result = JsonSerializationTool<ResultObject>.Serialize(resultObject);
                        break;


                    case "DELETE":
                        if (!long.TryParse(context.Request.QueryString["id"], out objectId))
                        {
                            //ERROR
                        }
                        var deleteResultObject = Delete(objectId);
                        result = JsonSerializationTool<ResultObject>.Serialize(deleteResultObject);
                        break;
                }

                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.ToString());
            }
        }



        public virtual List<T> Get()
        {
            return null;
        }

        public virtual T Get(long id)
        {
            return default(T);
        }

        // = CREATE / REPLACE
        public virtual ResultObject Post(T receivedObject)
        {
            return new ResultObject(HttpStatusCode.NotImplemented, "Create feature not available for this object", (new StackTrace()).ToString());
        }

        // = UPDATE
        public virtual ResultObject Put(long id, string receivedJson)
        {
            return new ResultObject(HttpStatusCode.NotImplemented, "Update feature not available for this object", (new StackTrace()).ToString());
        }

        public virtual ResultObject Delete(long id)
        {
            return new ResultObject(HttpStatusCode.NotImplemented, "Delete feature not available for this object", (new StackTrace()).ToString());
        }


        public virtual string Serialize(T toSerialize)
        {
            var task = Task.Run(() =>
            {
            string result = null;// serializer.ToJSON(toSerialize, new JSONParameters()
                return result;
            });
            task.Wait();
            return task.Result;
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