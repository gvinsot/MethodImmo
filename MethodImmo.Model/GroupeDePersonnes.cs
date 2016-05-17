using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class GroupeDePersonnes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Label { get; set; }

        [InverseProperty("Groupes")]
        public virtual ICollection<Personne> Personnes { get; set; }

        [InverseProperty("OrigineGroupeDePersonnes")]
        public virtual ICollection<Document> Documents { get; set; }

        [InverseProperty("OrigineGroupeDePersonnes")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }

        [InverseProperty("Contractants")]
        public virtual ICollection<Contrat> Contrats { get; set; }
    }
}