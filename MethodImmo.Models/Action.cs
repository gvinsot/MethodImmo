
namespace MethodImmo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public  class Action
    {
       
        public long Id { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeDebutDeRealisation { get; set; }
        public DateTime DateDeFinDeRealisationConstate { get; set; }
        public DateTime DateDeFinDeRealisationPrevisionnelle { get; set; }
        public TypeAction TypeAction { get; set; }
    
        public Contrat OrigineContrat { get; set; }
        public List<Action> SousActions { get; set; }
        public Action ActionParente { get; set; }
        
        public List<CompteBancaire> ComptesBancaires { get; set; }
        
        public List<Commentaire> Commentaires { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .HasOne<Contrat>(el => el.OrigineContrat);
            modelBuilder.Entity<Action>()
                .HasOne<Action>(el => el.ActionParente);
            modelBuilder.Entity<Action>()
                .HasMany<Action>(el => el.SousActions);
        }
    }
}
