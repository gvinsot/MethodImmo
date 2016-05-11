using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Lot
    {
        public long Id;
        public string Description;
        public int Tantiemes;
        public Dictionary<DateTime, Contrat> Propriete;
        public Dictionary<DateTime, Contrat> Occupation;
        public IQueryable<Document> Documents;
        public IQueryable<Commentaire> Commentaires;
        public IQueryable<Anomalie> Anomalies;
    }
}