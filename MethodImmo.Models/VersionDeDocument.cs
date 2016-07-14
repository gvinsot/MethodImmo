
namespace MethodImmo.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class VersionDeDocument
    {
        public long Id { get; set; }
        public System.DateTime Date { get; set; }
        public string CheminDocument { get; set; }
    
        public Documentation Documentation { get; set; }
        
        public List<Anomalie> Anomalie { get; set; }
    }
}
