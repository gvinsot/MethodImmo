
namespace MethodImmo.Models
{

    public  class CoordonneesBancaires
    {
        public long Id { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
        public string Proprietaire { get; set; }
    
        public CompteBancaire CompteBancaire { get; set; }
        public Personne Personne { get; set; }
    }
}
