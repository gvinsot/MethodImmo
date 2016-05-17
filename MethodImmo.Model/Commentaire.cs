using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Commentaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Creation { get; set; }
        public string Contenu { get; set; }

        //public long? AuteurId { get; set; }
        //[ForeignKey("AuteurId")]
        [InverseProperty("TousLesCommentaires")]
        public virtual Individu Auteur { get; set; }

        //public long? OrigineActionId { get; set; }
        //[ForeignKey("OrigineActionId")]
        public virtual Action OrigineAction { get; set; }

        //public long? OrigineContratId { get; set; }
        //[ForeignKey("OrigineContratId")]
        public virtual Contrat OrigineContrat { get; set; }

        //public long? OrigineLotId { get; set; }
        //[ForeignKey("OrigineLotId")]
        public virtual Lot OrigineLot { get; set; }

        //public long? OrigineImmeubleId { get; set; }
        //[ForeignKey("OrigineImmeubleId")]
        public virtual Immeuble OrigineImmeuble { get; set; }

        //public long? OriginePersonneId { get; set; }
        //[ForeignKey("OriginePersonneId")]
        public virtual Personne OriginePersonne { get; set; }

        //public long? OrigineGroupeDePersonnesId { get; set; }
        //[ForeignKey("OrigineGroupeDePersonnesId")]
        public virtual GroupeDePersonnes OrigineGroupeDePersonnes { get; set; }

        //public long? OrigineOperationBancaireId { get; set; }
        //[ForeignKey("OrigineOperationBancaireId")]
        public virtual OperationBancaire OrigineOperationBancaire { get; set; }

        //public long? OrigineAdresseId { get; set; }
        //[ForeignKey("OrigineAdresseId")]
        public virtual Adresse OrigineAdresse { get; set; }

    }
}