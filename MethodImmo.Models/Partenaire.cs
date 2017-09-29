
namespace MethodImmo.Models
{
    public  class Partenaire
    {
        public long Id { get; set; }
        public string FonctionDuPartenaire { get; set; }
    
        public Personne Personne { get; set; }
        public Personne PartenaireDe { get; set; }


        //public static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Partenaire>()
        //        .HasOne<Personne>(im => im.PartenaireDe);
        //    modelBuilder.Entity<Partenaire>()
        //        .HasOne<Personne>(im => im.Personne);
        //}
    }
}
