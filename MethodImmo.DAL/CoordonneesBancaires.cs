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
    
    public partial class CoordonneesBancaires
    {
        public long Id { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
        public string Proprietaire { get; set; }
    
        public virtual CompteBancaire CompteBancaire { get; set; }
        public virtual Personne Personne { get; set; }
    }
}
