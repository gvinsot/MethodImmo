using MethodImmo.Business;
using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;

namespace MethodImmo.Services.ViewModels
{
    /// <summary>
    /// Summary description for Lot
    /// </summary>
    public class LotService : GenericHandler
    {
        public override object Get(MethodImmoContext context, NameValueCollection queryString)
        {
            LotManager manager = new LotManager(); 
            

            if (queryString["id"] != null)
            {
                Int64 id = Int64.Parse(queryString["id"]);
                return manager.GetLot(id, context.LotSet);
            }
            IQueryable<Lot> query = context.LotSet;

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
                //context.LotSet.Add(received);
                //context.SaveChanges();
                //id = received.Id;
            }
            return new ResultObject(HttpStatusCode.OK, "Lot créé", id.ToString());
        }

        public override ResultObject Put(string receivedJson, NameValueCollection queryString)
        {
            Int64 id = Int64.Parse(queryString["id"]);
            using (var context = new MethodImmoContext())
            {
                
                var toUpdate = context.PersonneSet.Find(id);

                JsonSerializationTool<object>.FillObject(receivedJson,toUpdate);

                context.SaveChanges();
            }
            return new ResultObject(HttpStatusCode.OK, "Lot mis à jour","id = "+id);
        }

        public override ResultObject Delete(NameValueCollection queryString)
        {
            Int64 id = Int64.Parse(queryString["id"]);
            using (var context = new MethodImmoContext())
            {
                var toDelete = new Lot() { Id = id };
                context.LotSet.Attach(toDelete);
                context.LotSet.Remove(toDelete);
                context.SaveChanges();
            }
            return new ResultObject(HttpStatusCode.OK, "Lot supprimé", "id = " + id);
        }

        public override string Serialize(object toSerialize)
        {
            return base.Serialize(toSerialize);
        }
    }
}