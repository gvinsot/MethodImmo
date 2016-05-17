using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public TypeDeDocument TypeDeDocument { get; set; }

        [InverseProperty("Document")]
        public virtual ICollection<DocumentVersion> Versions { get; set; }

        //public long? OrigineActionId { get; set; }
        //[ForeignKey("OrigineActionId")]
        public virtual Action OrigineAction { get; set; }

        //public long? OrigineLotId { get; set; }
        //[ForeignKey("OrigineLotId")]
        public virtual Lot OrigineLot { get; set; }

        //public long? OrigineContratId { get; set; }
        //[ForeignKey("OrigineContratId")]
        public virtual Contrat OrigineContrat { get; set; }

        //public long? OrigineCompteBancaireId { get; set; }
        //[ForeignKey("OrigineCompteBancaireId")]
        public virtual CompteBancaire OrigineCompteBancaire { get; set; }

        //public long? OrigineImmeubleId { get; set; }
        //[ForeignKey("OrigineImmeubleId")]
        public virtual Immeuble OrigineImmeuble { get; set; }

        //public long? OriginePersonneId { get; set; }
        //[ForeignKey("OriginePersonneId")]
        public virtual Personne OriginePersonne { get; set; }

        //public long? OrigineGroupeDePersonnesId { get; set; }
        //[ForeignKey("OrigineGroupeDePersonnesId")]
        public virtual GroupeDePersonnes OrigineGroupeDePersonnes { get; set; }
    }

    public class DocumentVersion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string VersionPath { get; set; }

        public long? DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Document Document { get; set; }


        [InverseProperty("OrigineDocumentVersion")]
        public virtual ICollection<Action> Anomalies { get; set; }

    }
}