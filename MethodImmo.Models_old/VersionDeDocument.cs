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
    
    public  class VersionDeDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VersionDeDocument()
        {
            this.Anomalie = new HashSet<Anomalie>();
        }
    
        public long Id { get; set; }
        public System.DateTime Date { get; set; }
        public string CheminDocument { get; set; }
    
        public virtual Documentation Documentation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anomalie> Anomalie { get; set; }
    }
}
