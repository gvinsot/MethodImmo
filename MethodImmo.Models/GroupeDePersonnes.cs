
namespace MethodImmo.Models
{
    using System.Collections.Generic;

    public  class GroupeDePersonnes
    {
        public long Id { get; set; }
        public string Nom { get; set; }
    
        public List<Contrat> Contrats { get; set; }
        public List<DroitsGroupeUtilisateurs> DroitsGroupeUtilisateurs { get; set; }
        public List<Personne> Personnes { get; set; }
        public Entreprise EntrepriseDAppartenance { get; set; }
        public Lot GroupeDOccupants { get; set; }


        //public static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<GroupeDePersonnes>()
        //        .HasMany<Contrat>(im => im.Contrats);
        //}
    }
}
