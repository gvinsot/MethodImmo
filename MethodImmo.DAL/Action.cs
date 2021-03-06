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
    
    public partial class Action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Action()
        {
            this.ComptesBancaires = new HashSet<CompteBancaire>();
            this.Commentaires = new HashSet<Commentaire>();
        }
    
        public long Id { get; set; }
        public System.DateTime DateDeCreation { get; set; }
        public System.DateTime DateDeDebutDeRealisation { get; set; }
        public System.DateTime DateDeFinDeRealisationConstate { get; set; }
        public System.DateTime DateDeFinDeRealisationPrevisionnelle { get; set; }
        public TypeAction TypeAction { get; set; }
    
        public virtual Contrat OrigineContrat { get; set; }
        public virtual Action SousActions { get; set; }
        public virtual Action ActionParente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompteBancaire> ComptesBancaires { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }
    }
}
