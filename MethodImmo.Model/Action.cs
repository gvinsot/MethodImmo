using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime DateDeDeclaration { get; set; }

        public string Description { get; set; }
        public TimeSpan? PeriodeDeRecurrence { get; set; }
        public DateTime ProchaineExecutionPrevue { get; set; }
        public StatusAction Status { get; set; }

        //public long? ParentActionId { get; set; }
        //[ForeignKey("ParentActionId")]
        public virtual Action ParentAction { get; set; }

        [InverseProperty("ParentAction")]
        public virtual ICollection<Action> SousActions { get; set; }

        [InverseProperty("OrigineAction")]
        public virtual ICollection<Document> Documents { get; set; }

        [InverseProperty("OrigineAction")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }

        //public long? OrigineLotId { get; set; }
        //[ForeignKey("OrigineLotId")]
        public virtual Lot OrigineLot { get; set; }

       // public long? OrigineContratId { get; set; }
        //[ForeignKey("OrigineContratId")]
        public virtual Contrat OrigineContrat { get; set; }

        //public long? OrigineImmeubleId { get; set; }
        //[ForeignKey("OrigineImmeubleId")]
        public virtual Immeuble OrigineImmeuble { get; set; }

        //public long? OriginePersonneId { get; set; }
        //[ForeignKey("OriginePersonneId")]
        public virtual Personne OriginePersonne { get; set; }

        //public long? OrigineGroupeDePersonnesId { get; set; }
       // [ForeignKey("OrigineGroupeDePersonnesId")]
        public virtual GroupeDePersonnes OrigineGroupeDePersonnes { get; set; }

        //public long? OrigineAdresseId { get; set; }
        //[ForeignKey("OrigineAdresseId")]
        public virtual Adresse OrigineAdresse { get; set; }

        //public long? OrigineCompteBancaireId { get; set; }
        //[ForeignKey("OrigineCompteBancaireId")]
        public virtual CompteBancaire OrigineCompteBancaire { get; set; }

        //public long? OrigineOperationBancaireId { get; set; }
        //[ForeignKey("OrigineOperationBancaireId")]
        public virtual OperationBancaire OrigineOperationBancaire { get; set; }

        //public long? OrigineDocumentVersionId { get; set; }
        //[ForeignKey("OrigineDocumentVersionId")]
        public virtual DocumentVersion OrigineDocumentVersion { get; set; }
    }
}