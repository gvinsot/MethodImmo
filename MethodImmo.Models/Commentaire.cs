
namespace MethodImmo.Models
{
    public  class Commentaire
    {
        public long Id { get; set; }
        public string Contenu { get; set; }
        public string DateDeCreation { get; set; }
    
        public Contrat CommentaireDeContrat { get; set; }
        public Action CommentaireDAction { get; set; }
        public Personne CommentaireDePersonne { get; set; }
        public Lot CommentaireDeLot { get; set; }
        public Immeuble CommentaireDeImmeuble { get; set; }
        public Individu Auteur { get; set; }


        //public static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Commentaire>()
        //        .HasOne<Contrat>(im => im.CommentaireDeContrat);
        //    modelBuilder.Entity<Commentaire>()
        //        .HasOne<Action>(im => im.CommentaireDAction);
        //    modelBuilder.Entity<Commentaire>()
        //        .HasOne<Personne>(im => im.CommentaireDePersonne);
        //    modelBuilder.Entity<Commentaire>()
        //        .HasOne<Lot>(im => im.CommentaireDeLot);
        //    modelBuilder.Entity<Commentaire>()
        //        .HasOne<Immeuble>(im => im.CommentaireDeImmeuble);
        //    modelBuilder.Entity<Commentaire>()
        //        .HasOne<Individu>(im => im.Auteur);
        //}
    }
}
