using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class AccesUtilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [InverseProperty("OrigineDuDroit")]
        public virtual ICollection<DroitUtilisateur> Droits { get; set; }

        [InverseProperty("OrigineAccesUtilisateur")]
        public virtual ICollection<Action> Anomalies { get; set; }
    }
}