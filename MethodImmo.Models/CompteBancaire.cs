
namespace MethodImmo.Models
{
    using System.Collections.Generic;

    public  class CompteBancaire
    {
        public long Id { get; set; }
        public string Nom { get; set; }
    
        public Immeuble Immeuble { get; set; }
        
        public List<CoordonneesBancaires> CoordonneesBancaires { get; set; }
        
        public List<Documentation> Documentation { get; set; }
        
        public List<Anomalie> Anomalie { get; set; }
        public Action Action { get; set; }
        
    }
}
