
namespace MethodImmo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public  class CoordonneesDeContact
    {
    
        public long Id { get; set; }
    
        
        public List<Telephone> Telephones { get; set; }
        
        public List<AdresseEmail> AdressesEmails { get; set; }
        
        public List<AdressePostale> AdressesPostales { get; set; }
        public Personne Personne { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoordonneesDeContact>()
                .HasMany<AdresseEmail>(im => im.AdressesEmails);
            modelBuilder.Entity<CoordonneesDeContact>()
                .HasMany<AdressePostale>(im => im.AdressesPostales);
        }
    }
}
