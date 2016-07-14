


//





namespace MethodImmo.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class Telephone
    {
        public long Id { get; set; }
        public string Numero { get; set; }
    
        public CoordonneesDeContact CoordonneesDeContact { get; set; }
    }
}
