


//





namespace MethodImmo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public  class DroitsGroupeUtilisateurs
    {
        
        public long Id { get; set; }
        public TypeDeDroit TypeDeDroit { get; set; }
    
        public GroupeDePersonnes GroupeDePersonnes { get; set; }
        
        public List<Immeuble> Immeubles { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DroitsGroupeUtilisateurs>()
                .HasMany<Immeuble>(im => im.Immeubles);
        }
    }
}
