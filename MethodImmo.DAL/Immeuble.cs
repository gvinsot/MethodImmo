//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MethodImmo.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Immeuble
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Immeuble()
        {
            this.Adresses = new HashSet<AdressePostale>();
            this.CompteBancaire = new HashSet<CompteBancaire>();
            this.Lot = new HashSet<Lot>();
            this.Commentaires = new HashSet<Commentaire>();
        }
    
        public long Id { get; set; }
        public string Nom { get; set; }
        public string TotalTantiemes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdressePostale> Adresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompteBancaire> CompteBancaire { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lot> Lot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }
    }
}
