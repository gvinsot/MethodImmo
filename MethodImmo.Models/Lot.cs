
namespace MethodImmo.Models
{
     
    using System;
    using System.Collections.Generic;

    public  class Lot
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string BatimentEscalier { get; set; }
        public string Etage { get; set; }
        public TypeDeLot TypeDeLot { get; set; }
        public Nullable<double> Superficie { get; set; }
        public TypeDUsage Usage { get; set; }
    
        public Immeuble Immeuble { get; set; }
        public GroupeDeRepartition Proprietaires { get; set; }
        public GroupeDeRepartition Occupants { get; set; }
        
        public List<Commentaire> Commentaires { get; set; }
        
        public List<CleDeRepartition> ClesDeRepartition { get; set; }

        //public static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Lot>()
        //        .HasOne<Immeuble>(im => im.Immeuble);
        //    modelBuilder.Entity<Lot>()
        //        .HasOne<GroupeDeRepartition>(im => im.Proprietaires);
        //    modelBuilder.Entity<Lot>()
        //        .HasOne<GroupeDeRepartition>(im => im.Occupants);
        //    modelBuilder.Entity<Lot>()
        //        .HasMany<Commentaire>(im => im.Commentaires);
        //    modelBuilder.Entity<Lot>()
        //        .HasMany<CleDeRepartition>(im => im.ClesDeRepartition);
        //}
    }
}
