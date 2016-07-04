using MethodImmo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Business
{
    public class IndividuManager
    {
        public IQueryable<Individu> Search(string searchString, IQueryable<Individu> Individus)
        {
            if (string.IsNullOrEmpty(searchString))
                return Individus;

            var searchStringLowered = searchString.ToLower();
            var result = from individu in Individus where individu.Nom.ToLower().Contains(searchStringLowered) select individu;
            return result;
        }

        public Individu GetIndividu(Int64 id, DbSet<Personne> Individus)
        {
            var result = Individus.First(el=>el.Id==id);
            return result as Individu;
        }
    }
}
