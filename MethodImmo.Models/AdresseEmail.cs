
namespace MethodImmo.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class AdresseEmail
    {
        public long Id { get; set; }
        public string Email { get; set; }
    
        public CoordonneesDeContact CoordonneesDeContact { get; set; }
    }
}
