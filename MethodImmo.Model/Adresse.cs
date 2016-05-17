using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public virtual ICollection<AdressePostale> AdressesPhysiques { get; set; }
        public virtual ICollection<Email> AdressesElectroniques { get; set; }
        public virtual ICollection<Telephone> NumerosDeTelephones { get; set; }

        [InverseProperty("OrigineAdresse")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }

        [InverseProperty("OrigineAdresse")]
        public virtual ICollection<Action> Anomalies { get; set; }



        //public long? OrigineImmeubleId { get; set; }
        //[ForeignKey("OrigineImmeubleId")]
        public virtual Immeuble OrigineImmeuble { get; set;}


        //public long? OriginePersonneId { get; set; }
        //[ForeignKey("OriginePersonneId")]
        public virtual Personne OriginePersonne { get; set; }

    }

    public class Email
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Adresse { get; set; }
    }

    public class AdressePostale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Adresse { get; set; }
    }


    public class Telephone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Numero { get; set; }
    }
}