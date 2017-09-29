namespace MethodImmo.Models
{

    public  class Telephone
    {
        public long Id { get; set; }
        public string Numero { get; set; }
    
        public CoordonneesDeContact CoordonneesDeContact { get; set; }
    }
}
