namespace MethodImmo.Models
{
    public  class GroupeDeRepartition : GroupeDePersonnes
    {
    
        public Lot GroupeDeProprietaires { get; set; }

        //public new static void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<GroupeDeRepartition>()
        //        .HasOne<Lot>(im => im.GroupeDeProprietaires);
        //}
    }
}
