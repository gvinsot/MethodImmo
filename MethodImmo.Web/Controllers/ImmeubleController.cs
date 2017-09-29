using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MethodImmo.Business;
using MethodImmo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MethodImmo.Web.Controllers
{
    [Route("api/[controller]")]
    public class ImmeubleController : Controller
    {
        //private MethodImmoContext _context;


        //public ImmeubleController(MethodImmoContext context)
        //{
        //    _context = context;
        //}

        // GET: api/values
        [HttpGet]
        public List<Immeuble> Get([FromQuery] string search=null)
        {
            //ImmeubleManager manager = new ImmeubleManager();
            //IQueryable<Immeuble> query = _context.ImmeubleSet;
            //if (!String.IsNullOrWhiteSpace(search) && search!="null")
            //    query = manager.Search(search, query);

            //List<Immeuble> result = query.ToList();

            //return result;            
            return new List<Immeuble>() { new Immeuble() {Nom="test" ,Id=1234,Adresses=new List<AdressePostale>() { new AdressePostale() { Rue="Flandrin",CodePostal="75016",Id=1234,Ville="Paris" } } } };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
