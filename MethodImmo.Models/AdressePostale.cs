
namespace MethodImmo.Models
{

    public  class AdressePostale
    {
        public AdressePostale()
        {
            this.Pays = "France";
        }
    
        public long Id { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string CodeAcces { get; set; }
        public string InfoAcces { get; set; }
        public string RueL2 { get; set; }
    
        public CoordonneesDeContact CoordonneesDeContact { get; set; }
        public Immeuble Immeuble { get; set; }
    }
}
