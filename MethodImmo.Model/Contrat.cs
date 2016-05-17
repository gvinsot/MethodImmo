using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Contrat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime DateApplication{ get; set; }
        public DateTime? DateDeFin{ get; set; }
        public TimeSpan? RenouvellementAutomatique{ get; set; }
        public TypeDeContrat TypeDeContrat{ get; set; }
        public string DenominationContractant1{ get; set; }


        [InverseProperty("Contrats")]
        public virtual ICollection<GroupeDePersonnes> Contractants { get; set; }

        [InverseProperty("OrigineContrat")]
        public virtual ICollection<Document> Documents { get; set; }

        [InverseProperty("OrigineContrat")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }

        [InverseProperty("OrigineContrat")]
        public virtual ICollection<Action> Anomalies { get; set; }


        public long? OrigineLotId { get; set; }
        [ForeignKey("OrigineLotId")]
        public virtual Lot OrigineProprieteLot { get; set; }

        public virtual Lot OrigineOccupationLot { get; set; }
    }
}