using MethodImmo.DataAccessLayer;
using MethodImmo.EntityJsonSerializer;
using MethodImmo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MethodImmo.Services.viewmodels
{
    /// <summary>
    /// Summary description for Immeuble
    /// </summary>
    public class ImmeubleService : GenericHandler<Immeuble>
    {
        public override List<Immeuble> Get()
        {
            using (var context = new MethodImmoDb())
            {                
                return context.Immeubles.ToList();
            }             
        }

        public override Immeuble Get(long id)
        {
            using (var context = new MethodImmoDb())
            {
                return context.Immeubles.Find(id);
            }
        }

        public override ResultObject Post(Immeuble received)
        {
            long id = -1;
            using (var context = new MethodImmoDb())
            {
                context.Immeubles.Add(received);
                context.SaveChanges();
                id = received.Id;
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble créé", id.ToString());
        }

        public override ResultObject Put(long id, string receivedJson)
        {
            using (var context = new MethodImmoDb())
            {
                
                var toUpdate = context.Immeubles.Find(id);

                var serializer = new JsonEntitySerializer();
                serializer.FillObject(toUpdate, receivedJson);

                context.SaveChanges();
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble mis à jour","id = "+id);
        }

        public override ResultObject Delete(long id)
        {
            using (var context = new MethodImmoDb())
            {
                var toDelete = new Immeuble() { Id = id };
                context.Immeubles.Attach(toDelete);
                context.Immeubles.Remove(toDelete);
                context.SaveChanges();
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble supprimé", "id = " + id);
        }



        public override string Serialize(Immeuble toSerialize)
        {
            return base.Serialize(toSerialize);
        }
    }
}