
namespace MethodImmo.DataAccessLayer
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using MethodImmo.Models;
    using System.Reflection;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.IO;

    public class MethodImmoContext : DbContext
    {
        public MethodImmoContext(DbContextOptions<MethodImmoContext> options)
        : base(options)
        {
        }
        public MethodImmoContext():base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // JsonConvert.DeserializeObject(File.ReadAllText("appsettings.json"));
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=methodimmodb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyName= Assembly.GetEntryAssembly().GetReferencedAssemblies().First(el => el.Name=="MethodImmo.Models");
            var assembly = Assembly.Load(assemblyName);
            var types =  GetTypesInNamespace(assembly, "MethodImmo.Models");
            
            foreach (var type in types)
            {
                var method = type.GetMethod("OnModelCreating");
                if(method!=null)
                {
                    method.Invoke(null,new object[] { modelBuilder });
                }
            }
        }
            
        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public virtual DbSet<AccesUtilisateur> AccesUtilisateurSet { get; set; }
        public virtual DbSet<MethodImmo.Models.Action> ActionSet { get; set; }
        public virtual DbSet<Commentaire> CommentaireSet { get; set; }
        public virtual DbSet<CompteBancaire> CompteBancaireSet { get; set; }
        public virtual DbSet<Contrat> ContratSet { get; set; }
        public virtual DbSet<CoordonneesBancaires> CoordonneesBancairesSet { get; set; }
        public virtual DbSet<Documentation> DocumentationSet { get; set; }
        public virtual DbSet<DroitsGroupeUtilisateurs> DroitsGroupeUtilisateursSet { get; set; }
        public virtual DbSet<GroupeDePersonnes> GroupeDePersonnesSet { get; set; }
        public virtual DbSet<Immeuble> ImmeubleSet { get; set; }
        public virtual DbSet<Personne> PersonneSet { get; set; }
        public virtual DbSet<CoordonneesDeContact> CoordonneesDeContactSet { get; set; }
        public virtual DbSet<AdressePostale> AdressePostaleSet { get; set; }
        public virtual DbSet<AdresseEmail> AdresseEmailSet { get; set; }
        public virtual DbSet<Telephone> TelephoneSet { get; set; }
        public virtual DbSet<VersionDeDocument> VersionDeDocumentSet { get; set; }
        public virtual DbSet<Lot> LotSet { get; set; }
        public virtual DbSet<Partenaire> PartenaireSet { get; set; }
        public virtual DbSet<CleDeRepartition> CleDeRepartitionSet { get; set; }
    }
}
