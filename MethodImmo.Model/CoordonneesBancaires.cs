using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    [ComplexType]
    public class CoordonneesBancaires
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long Id { get; set; }
        public string NomDuProprietaireDuCompte { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }

        
        //public long? CompteBancaireId { get; set; }

        //[InverseProperty("CoordonneesBancaires")]
        //[ForeignKey("CompteBancaireId")]
        //public virtual CompteBancaire CompteBancaire { get; set; }


    }
}