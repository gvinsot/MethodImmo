using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class AccesUtilisateur
    {
        public long Id;
        public List<DroitUtilisateur> Droits;
        public IQueryable<Anomalie> Anomalies;
    }
}