using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Action
    {
        public long Id;
        public string Description;
        public TimeSpan? PeriodeDeRecurrence;
        public DateTime ProchaineExecutionPrevue;
        public IQueryable<Document> Documents;
        public StatusAction Status;
        public TypesApplicables OrigineType;
        public long OrigineId;
        public List<Action> SousActions;
        public IQueryable<Commentaire> Commentaires;
    }
}