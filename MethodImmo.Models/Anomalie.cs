
namespace MethodImmo.Models
{
    public  class Anomalie : Action
    {
    
        public Documentation AnomalieDeDocumentation { get; set; }
        public VersionDeDocument AnomalieDeVersionDeDocument { get; set; }
        public Contrat AnomalieDeContrat { get; set; }
        public CompteBancaire AnomalieDeCompteBancaire { get; set; }


        //public static new void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Anomalie>()
        //        .HasOne<Documentation>(el => el.AnomalieDeDocumentation);
        //    modelBuilder.Entity<Anomalie>()
        //        .HasOne<VersionDeDocument>(el => el.AnomalieDeVersionDeDocument);
        //    modelBuilder.Entity<Anomalie>()
        //        .HasOne<Contrat>(el => el.AnomalieDeContrat);
        //    modelBuilder.Entity<Anomalie>()
        //        .HasOne<CompteBancaire>(el => el.AnomalieDeCompteBancaire);
        //}
    }
}
