
namespace MethodImmo.Models
{
    using System.Collections.Generic;

    public class Individu : Personne
    {

        public string Prenom { get; set; }


        public List<Commentaire> CommentairesEmis { get; set; }


        public AccesUtilisateur AccesUtilisateur { get; set; }

        //public new static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Individu>()
        //        .HasOne(p => p.AccesUtilisateur)
        //        .WithOne(i => i.Individu)
        //        .HasForeignKey<AccesUtilisateur>(b => b.IndividuForeignKey);
        //}
    }
}
