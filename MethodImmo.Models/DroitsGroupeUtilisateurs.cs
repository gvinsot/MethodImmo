//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MethodImmo.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class DroitsGroupeUtilisateurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DroitsGroupeUtilisateurs()
        {
            this.Immeubles = new HashSet<Immeuble>();
        }
    
        public long Id { get; set; }
        public TypeDeDroit TypeDeDroit { get; set; }
    
        public virtual GroupeDePersonnes GroupeDePersonnes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Immeuble> Immeubles { get; set; }
    }
}
