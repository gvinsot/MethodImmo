using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Contrat
    {
        public long Id;
        public DateTime DateDeCreation;
        public DateTime DateApplication;
        public DateTime? DateDeFin;
        public TimeSpan? RenouvellementAutomatique;
        public TypeDeContrat TypeDeContrat;
        public string DenominationContractant1;
        public GroupeDePersonnes Contractant1;
        public string DenominationContractant2;
        public GroupeDePersonnes Contractant2;
        public IQueryable<Document> Documents;
        public IQueryable<Action> Actions;
        public IQueryable<Anomalie> Anomalies;
    }
}