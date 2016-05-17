using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Personne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id{ get; set; }

        [Required]
        public string Nom{ get; set; }

        public DateTime? DateDeNaissance{ get; set; }
        public DateTime? DateDeMort{ get; set; }

        public virtual ICollection<GroupeDePersonnes> Groupes { get; set; }

        [InverseProperty("OriginePersonne")]
        public virtual ICollection<Adresse> Adresses{ get; set; }

        [InverseProperty("OriginePersonne")]
        public virtual ICollection<Document> Documents { get; set; }

        [InverseProperty("OriginePersonne")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }

        [InverseProperty("OriginePersonne")]
        public virtual ICollection<Action> Anomalies { get; set; }
    }
}