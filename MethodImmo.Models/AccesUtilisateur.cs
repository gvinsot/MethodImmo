
namespace MethodImmo.Models
{


    public class AccesUtilisateur
    {
        public long Id { get; set; }
        public string MotDePasse { get; set; }
        public string Utilisateur { get; set; }

        public Individu Individu { get; set; }
        public long IndividuId { get; set; }
    }
}
