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
    
    public partial class AdressePostale
    {
        public long Id { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Acces { get; set; }
    
        public virtual CoordonneesDeContact CoordonneesDeContact { get; set; }
        public virtual Immeuble Immeuble { get; set; }
    }
}