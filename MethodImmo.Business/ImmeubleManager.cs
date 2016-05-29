﻿using MethodImmo.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Business
{
    public class ImmeubleManager
    {
        public IQueryable<Immeuble> Search(string searchString, IQueryable<Immeuble> immeubles)
        {
            if (string.IsNullOrEmpty(searchString))
                return immeubles;

            var searchStringLowered = searchString.ToLower();
            var result = from immeuble in immeubles where immeuble.Nom.ToLower().Contains(searchStringLowered) select immeuble;
            return result;
        }

        public Immeuble GetIndividu(Int64 id, DbSet<Immeuble> immeubles)
        {
            var result = immeubles.Find(id);
            return result;
        }
    }
}
