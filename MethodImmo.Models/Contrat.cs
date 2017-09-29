
namespace MethodImmo.Models
{
    using System.Collections.Generic;

    public  class Contrat
    {
        public long Id { get; set; }
        public System.DateTime DateDeDebut { get; set; }
        public System.DateTime DateDeFin { get; set; }
        public string TypeDeContrat { get; set; }

        public List<GroupeDePersonnes> GroupesContractants { get; set; }
        
        public List<Documentation> Documentation { get; set; }
        
        public List<Action> Actions { get; set; }
        
        public List<Anomalie> Anomalie { get; set; }
        
        public List<Commentaire> Commentaires { get; set; }

        //public static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Contrat>()
        //        .HasMany<GroupeDePersonnes>(im => im.GroupesContractants);            
        //}
    }
}
