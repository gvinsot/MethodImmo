using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Personne
    {
        public long Id;
        public string Nom;

        public DateTime DateDeNaissance;
        public DateTime DateDeMort;

        public List<Contrat> Contrats;

        public List<Adresse> Adresses;


        public List<Document> Documents;

        public IQueryable<Commentaire> Commentaires;

        public IQueryable<Anomalie> Anomalies;
    }
}