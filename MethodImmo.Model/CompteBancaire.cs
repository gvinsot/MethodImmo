using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class CompteBancaire : Contrat
    {
        
        //public long? CoordonneesBancairesId { get; set; }
        //[ForeignKey("CoordonneesBancairesId")]
        //[InverseProperty("CompteBancaire")]
        public virtual CoordonneesBancaires CoordonneesBancaires { get; set; }

        //[InverseProperty("CompteBancaire")]
        public virtual ICollection<OperationBancaire> OperationsBancaires { get; set; }

        //[InverseProperty("OrigineCompteBancaire")]
        public virtual ICollection<Document> RelevesDeCompte { get; set; }


        //public long? OrigineImmeubleId { get; set; }
        //[ForeignKey("OrigineImmeubleId")]
        public virtual Immeuble OrigineImmeuble { get; set; }

        //public long? OriginePersonneId { get; set; }
        //[ForeignKey("OriginePersonneId")]
        public virtual Personne OriginePersonne { get; set; }
        
    }
}