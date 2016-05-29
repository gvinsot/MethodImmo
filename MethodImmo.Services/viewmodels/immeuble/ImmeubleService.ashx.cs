using MethodImmo.Business;
using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace MethodImmo.Services.ViewModels
{
    /// <summary>
    /// Summary description for Immeuble
    /// </summary>
    public class ImmeubleService : GenericHandler
    {
        public override object Get(MethodImmoContext context, NameValueCollection queryString)
        {
            ImmeubleManager manager = new ImmeubleManager();
            IQueryable<Immeuble> query = context.ImmeubleSet;
            if (queryString["search"] != null)
                query = manager.Search(queryString["search"], query);

            var result = query.ToList();

            return result;  
        }
        
        public override ResultObject Post(string receivedJson, NameValueCollection queryString)
        {
            long id = -1;
            using (var context = new MethodImmoContext())
            {
                //context.ImmeubleSet.Add(received);
                //context.SaveChanges();
                //id = received.Id;
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble créé", id.ToString());
        }

        public override ResultObject Put(string receivedJson, NameValueCollection queryString)
        {
            Int64 id = Int64.Parse(queryString["id"]);
            using (var context = new MethodImmoContext())
            {
                
                var toUpdate = context.ImmeubleSet.Find(id);

                JsonSerializationTool<object>.FillObject(receivedJson,toUpdate);

                context.SaveChanges();
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble mis à jour","id = "+id);
        }

        public override ResultObject Delete(NameValueCollection queryString)
        {
            Int64 id = Int64.Parse(queryString["id"]);
            using (var context = new MethodImmoContext())
            {
                var toDelete = new Immeuble() { Id = id };
                context.ImmeubleSet.Attach(toDelete);
                context.ImmeubleSet.Remove(toDelete);
                context.SaveChanges();
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble supprimé", "id = " + id);
        }

        public override string Serialize(object toSerialize)
        {
            return base.Serialize(toSerialize);
        }
    }
}