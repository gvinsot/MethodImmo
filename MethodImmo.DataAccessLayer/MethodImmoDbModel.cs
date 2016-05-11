namespace MethodImmo.DataAccessLayer
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MethodImmoDbModel : DbContext
    {
        public MethodImmoDbModel()
            : base("name=MethodImmoDbModel")
        {
        }
        public virtual DbSet<Immeuble> Immeubles { get; set; }
        public virtual DbSet<Individu> Individus { get; set; }
        public virtual DbSet<Entreprise> Entreprises   { get; set; }         
        public virtual DbSet<Contrat> Contrats { get; set; }
        public virtual DbSet<Model.Action> Actions { get; set; }
        
        //public virtual DbSet<Commentaire> Commentaires { get; set; }
    }    
}