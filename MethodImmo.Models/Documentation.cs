
namespace MethodImmo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public  class Documentation
    {
        public long Id { get; set; }
    
        public Contrat Contrat { get; set; }
        
        public List<VersionDeDocument> Versions { get; set; }
        
        public List<Anomalie> Anomalie { get; set; }
        public CompteBancaire CompteBancaire { get; set; }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documentation>()
                .HasMany<VersionDeDocument>(im => im.Versions);
        }
    }
}
