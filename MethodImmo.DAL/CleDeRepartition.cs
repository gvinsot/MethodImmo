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
    
    public partial class CleDeRepartition
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public long Tantiemes { get; set; }
    
        public virtual Lot Lot { get; set; }
    }
}
