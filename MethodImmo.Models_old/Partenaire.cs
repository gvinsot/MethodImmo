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
    
    public  class Partenaire
    {
        public long Id { get; set; }
        public string FonctionDuPartenaire { get; set; }
    
        public virtual Personne Personne { get; set; }
        public virtual Personne PartenaireDe { get; set; }
    }
}