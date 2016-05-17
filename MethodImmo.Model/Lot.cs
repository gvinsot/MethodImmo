using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Lot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id{ get; set; }
        public string Description{ get; set; }
        public int Tantiemes{ get; set; }

        [InverseProperty("OrigineProprieteLot")]
        public virtual ICollection<Contrat> HistoriquePropriete{ get; set; }

        [InverseProperty("OrigineOccupationLot")]
        public virtual ICollection<Contrat> HistoriqueOccupation{ get; set; }

        //public long? ImmeubleId { get; set; }
        //[ForeignKey("ImmeubleId")]
        public virtual Immeuble Immeuble { get; set; }

        [InverseProperty("OrigineLot")]
        public virtual ICollection<Document> Documents { get; set; }

        [InverseProperty("OrigineLot")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }

        [InverseProperty("OrigineLot")]
        public virtual ICollection<Action> Anomalies { get; set; }
    }
    
}