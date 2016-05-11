using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class CompteEnBanque : Contrat
    {
        public long Id;

        public CoordonneesBancaires CoordonneesBancaires;

        public IQueryable<OperationBancaire> OperationsBancaires;

        public IQueryable<Document> RelevesDeCompte;
    }
}