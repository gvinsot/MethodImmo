using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class GroupeDePersonnes
    {
        public long Id;
        public string Label;

        public List<Personne> Personnes;

        public IQueryable<Document> Documents;

        public IQueryable<Commentaire> Commentaires;


    }
}