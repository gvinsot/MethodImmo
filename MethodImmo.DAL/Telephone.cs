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
    
    public partial class Telephone
    {
        public long Id { get; set; }
        public string Numero { get; set; }
    
        public virtual CoordonneesDeContact CoordonneesDeContact { get; set; }
    }
}