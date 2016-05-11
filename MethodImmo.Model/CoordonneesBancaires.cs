using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class CoordonneesBancaires
    {
        public long Id;
        public string NomDuProprietaireDuCompte;
        public string BIC;
        public string IBAN;
        public IQueryable<Anomalie> Anomalies;
    }
}