using MethodImmo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Business
{
    public class LotManager
    {
        public IQueryable<Lot> Search(string searchString, IQueryable<Lot> Lots)
        {
            if (string.IsNullOrEmpty(searchString))
                return Lots;

            var searchStringLowered = searchString.ToLower();
            var result = from Lot in Lots where Lot.Nom.ToLower().Contains(searchStringLowered) select Lot;
            return result;
        }

        public Lot GetLot(Int64 id, IQueryable<Lot> Lots)
        {
            var result = Lots.FirstOrDefault(im => im.Id == id);
            return result;
        }
    }
}
