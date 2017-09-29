namespace MethodImmo.Models
{
     
    using System;
    using System.Collections.Generic;

    public  class Personne
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public Nullable<System.DateTime> DateDebut { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
    
        
        public List<Partenaire> Partenaires { get; set; }
        
        public List<CoordonneesDeContact> CoordonneesDeContact { get; set; }
        
        public List<CoordonneesBancaires> CoordonneesBancaires { get; set; }
        
        public List<Commentaire> CommentairesRecus { get; set; }

        //public static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Personne>()
        //        .HasMany<Partenaire>(im => im.Partenaires);
        //    modelBuilder.Entity<Personne>()
        //        .HasMany<CoordonneesDeContact>(im => im.CoordonneesDeContact);
        //    modelBuilder.Entity<Personne>()
        //        .HasMany<CoordonneesBancaires>(im => im.CoordonneesBancaires);
        //    modelBuilder.Entity<Personne>()
        //        .HasMany<Commentaire>(im => im.CommentairesRecus);
        //}
    }
}
