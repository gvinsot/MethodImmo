


//





namespace MethodImmo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public  class GroupeDeRepartition : GroupeDePersonnes
    {
    
        public Lot GroupeDeProprietaires { get; set; }

        public new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupeDeRepartition>()
                .HasOne<Lot>(im => im.GroupeDeProprietaires);
        }
    }
}
