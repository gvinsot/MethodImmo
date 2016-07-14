
namespace MethodImmo.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class AccesUtilisateur
    {
        public long Id { get; set; }
        public string MotDePasse { get; set; }
        public string Utilisateur { get; set; }

        public long IndividuForeignKey { get; set; }
        public Individu Individu { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccesUtilisateur>()
                .HasOne<Individu>(im => im.Individu);
        }
    }
}
