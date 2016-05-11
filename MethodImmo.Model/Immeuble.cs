using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Immeuble
    {
        public long Id;
        public string Label;

        public string Description;

        public List<Lot> Lots;
        public long TotalTantiemes;

        public List<Adresse> Adresses;

        public List<CompteEnBanque> ComptesEnBanque;

        public GroupeDePersonnes ConseilSyndical;

        public Entreprise Syndic;

        public IQueryable<Document> Documents;

        public IQueryable<Commentaire> Commentaires;

        public IQueryable<Anomalie> Anomalies;
    }
}