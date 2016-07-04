using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MethodImmo.Business;
using MethodImmo.Models;
using MethodImmo.DataAccessLayer;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MethodImmo.Web.Controllers
{
    [Route("api/[controller]")]
    public class ImmeubleController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<Immeuble> Get([FromBody] string search=null)
        {
            List<Immeuble> result = null;
            using (MethodImmoContext context = new MethodImmoContext(null))
            {
                ImmeubleManager manager = new ImmeubleManager();
                IQueryable<Immeuble> query = context.ImmeubleSet;
                if (!String.IsNullOrWhiteSpace(search))
                    query = manager.Search(search, query);

                result = query.ToList();
            }
            return result;
            
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
