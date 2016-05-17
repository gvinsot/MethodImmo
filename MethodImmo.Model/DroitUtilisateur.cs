using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Model
{
    public class DroitUtilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

       // public long? ImmeubleConcerneId { get; set; }
        //[ForeignKey("ImmeubleConcerneId")]
        [InverseProperty("DroitsUtilisateurApplicables")]
        public virtual Immeuble ImmeubleConcerne { get; set; }

        public TypeDeDroitUtilisateur TypeDeDroit { get; set; }

        //public long? UtilisateursConcerneId { get; set; }
        //[ForeignKey("UtilisateursConcerneId")]
        [InverseProperty("OrigineDroitsUtilisateur")]
        public virtual GroupeDePersonnes UtilisateursConcerne { get; set; }
    }
}
