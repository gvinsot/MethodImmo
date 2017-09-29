
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
            //var assemblyName= Assembly.GetEntryAssembly().GetReferencedAssemblies().First(el => el.Name=="MethodImmo.Models");
            //var assembly = Assembly.Load(assemblyName);
            //var types =  GetTypesInNamespace(assembly, "MethodImmo.Models");
            
            //foreach (var type in types)
            //{
            //    var method = type.GetMethod("OnModelCreating");
            //    if(method!=null)
            //    {
            //        method.Invoke(null,new object[] { modelBuilder });
            //    }
            //}
        }
            
        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public DbSet<AccesUtilisateur> AccesUtilisateurSet { get; set; }
        public  DbSet<MethodImmo.Models.Action> ActionSet { get; set; }
        public  DbSet<Commentaire> CommentaireSet { get; set; }
        public  DbSet<CompteBancaire> CompteBancaireSet { get; set; }
        public  DbSet<Contrat> ContratSet { get; set; }
        public  DbSet<CoordonneesBancaires> CoordonneesBancairesSet { get; set; }
        public  DbSet<Documentation> DocumentationSet { get; set; }
        public  DbSet<DroitsGroupeUtilisateurs> DroitsGroupeUtilisateursSet { get; set; }
        public  DbSet<GroupeDePersonnes> GroupeDePersonnesSet { get; set; }
        public  DbSet<Immeuble> ImmeubleSet { get; set; }
        public  DbSet<Personne> PersonneSet { get; set; }
        public  DbSet<CoordonneesDeContact> CoordonneesDeContactSet { get; set; }
        public  DbSet<AdressePostale> AdressePostaleSet { get; set; }
        public  DbSet<AdresseEmail> AdresseEmailSet { get; set; }
        public  DbSet<Telephone> TelephoneSet { get; set; }
        public  DbSet<VersionDeDocument> VersionDeDocumentSet { get; set; }
        public  DbSet<Lot> LotSet { get; set; }
        public  DbSet<Partenaire> PartenaireSet { get; set; }
        public  DbSet<CleDeRepartition> CleDeRepartitionSet { get; set; }
    }
}
