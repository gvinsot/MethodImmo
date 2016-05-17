using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Immeuble
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Label{ get; set; }

        public string Description{ get; set; }

        [InverseProperty("Immeuble")]
        public virtual ICollection<Lot> Lots{ get; set; }

        public long? TotalTantiemes{ get; set; }

        [InverseProperty("OrigineImmeuble")]
        public virtual ICollection<Adresse> Adresses{ get; set; }

        [InverseProperty("OrigineImmeuble")]
        public virtual ICollection<CompteBancaire> ComptesEnBanque{ get; set; }

        //[InverseProperty("ConseilImmeuble")]
        public virtual ConseilSyndical ConseilSyndical { get; set; }

        //public long? SyndicId { get; set; }
        //[ForeignKey("SyndicId")]
        //[InverseProperty("Immeuble")]
        public virtual Entreprise Syndic{ get; set; }

        [InverseProperty("OrigineImmeuble")]
        public virtual ICollection<Document> Documents{ get; set; }

        [InverseProperty("OrigineImmeuble")]
        public virtual ICollection<Commentaire> Commentaires{ get; set; }

        [InverseProperty("OrigineImmeuble")]
        public virtual ICollection<Action> Anomalies{ get; set; }
    }
}