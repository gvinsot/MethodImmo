
namespace MethodImmo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public  class Immeuble
    {
    
        public long Id { get; set; }
        public string Nom { get; set; }
    
        
        public List<AdressePostale> Adresses { get; set; }
        
        public List<CompteBancaire> ComptesBancaires { get; set; }
        
        public List<Lot> Lots { get; set; }
        
        public List<Commentaire> Commentaires { get; set; }
        
        public List<DroitsGroupeUtilisateurs> GroupesUtilisateursAvecAcces { get; set; }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Immeuble>()
                .HasMany<AdressePostale>(im => im.Adresses);
            modelBuilder.Entity<Immeuble>()
                .HasMany<CompteBancaire>(im => im.ComptesBancaires);
            modelBuilder.Entity<Immeuble>()
                .HasMany<Lot>(im => im.Lots);
            modelBuilder.Entity<Immeuble>()
                .HasMany<Commentaire>(im => im.Commentaires);
            modelBuilder.Entity<Immeuble>()
                .HasMany<DroitsGroupeUtilisateurs>(im => im.GroupesUtilisateursAvecAcces);
        }
    }
}
