using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MethodImmo.Services.ViewModels
{
    /// <summary>
    /// Summary description for Immeuble
    /// </summary>
    public class ImmeubleService : GenericHandler<Immeuble>
    {
        public override List<Immeuble> Get()
        {
            List<Immeuble> result = null;
            using (var context = new MethodImmoDb())
            {
                result = context.ImmeubleSet.ToList();
            }
            return result;  
        }

        public override Immeuble Get(long id)
        {
            Immeuble result = null;
            using (var context = new MethodImmoDb())
            {
                result = context.ImmeubleSet.Find(id);
            }
            return result;
        }

        public override ResultObject Post(Immeuble received)
        {
            long id = -1;
            using (var context = new MethodImmoDb())
            {
                context.ImmeubleSet.Add(received);
                context.SaveChanges();
                id = received.Id;
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble créé", id.ToString());
        }

        public override ResultObject Put(long id, string receivedJson)
        {
            using (var context = new MethodImmoDb())
            {
                
                var toUpdate = context.ImmeubleSet.Find(id);

                JsonSerializationTool<object>.FillObject(receivedJson,toUpdate);




                context.SaveChanges();
            }
            return new ResultObject(HttpStatusCode.OK, "Immeuble mis à jour","id = "+id);
        }

        public override ResultObject Delete(long id)
        {
            using (var context = new MethodImmoDb())
            {
                var toDelete = new Immeuble() { Id = id };
                context.ImmeubleSet.Attach(toDelete);
                context.ImmeubleSet.Remove(toDelete);
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