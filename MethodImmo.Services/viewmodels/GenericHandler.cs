using MethodImmo.EntityJsonSerializer;
using MethodImmo.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MethodImmo.Services.viewmodels
{
    /// <summary>
    /// Summary description for Immeuble
    /// </summary>
    public class GenericHandler<T> : IHttpHandler
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
                        var postSerializer = new JsonEntitySerializer();
                        T resultTObject = postSerializer.ToObject<T>(postSerialized);
                        result = postSerializer.ToJSON(Post(resultTObject));
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

                        var serializer = new JsonEntitySerializer();

                        result = serializer.ToJSON(resultObject);
                        break;


                    case "DELETE":
                        if (!long.TryParse(context.Request.QueryString["id"], out objectId))
                        {
                            //ERROR
                        }
                        var deleteResultObject = Delete(objectId);

                        var deleteSerializer = new JsonEntitySerializer();

                        result = deleteSerializer.ToJSON(deleteResultObject);
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
                var serializer = new JsonEntitySerializer();

                string result = serializer.ToJSON(toSerialize, new JSONParameters()
                {
                    AllowedLinks = new Dictionary<Type, List<string>>
                    {
                        //{typeof(Media),new List<string>{"Name","Trigger","OwnerWorkgroup","File"}},
                        //{typeof(Workgroup),new List<string>{"Id","Name"}},
                        //{typeof(File),new List<string>{"Id","Path","OriginalDuration","Width","Height"}},
                        //{typeof(Planning),new List<string>{"Id","StartDate","EndDate","IsOnMonday","IsOnTuesday"}}
                    }
                });
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