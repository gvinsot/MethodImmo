using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class OperationBancaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id{ get; set; }

        public DateTime Date{ get; set; }

        public double Emetteur{ get; set; }

        public double Recepteur{ get; set; }

        public string Description{ get; set; }

        public double Montant{ get; set; }

        [InverseProperty("OrigineOperationBancaire")]
        public virtual ICollection<Action> Anomalies{ get; set; }


        //public long? CompteBancaireId { get; set; }
        //[ForeignKey("CompteBancaireId")]
        public virtual CompteBancaire CompteBancaire { get; set; }
    }
}