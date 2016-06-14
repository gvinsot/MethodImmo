using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MethodImmo.DatabaseReset
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Dropping database...");
                DropAndRecreateDatabase("methodimmodb");
                Console.WriteLine("done.");
                Console.WriteLine("Running creation script...");
                string script = File.ReadAllText("MethodImmoDb.edmx.sql");
                RunScript("methodimmodb", script);
                Console.WriteLine("done.");
                Console.WriteLine("Creating Dataset...");
                CreateDataSet();
                Console.WriteLine("done.");
                Console.WriteLine("Creating Viewmodels...");
                CreateEmptyViewModels();
                Console.WriteLine("done.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void DropAndRecreateDatabase(string DbName)
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["MethodImmoContext"].ConnectionString.Split(new string[] { "connection string=", "\"" },StringSplitOptions.RemoveEmptyEntries).Last();

            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                string sqlCommandText = @"
ALTER DATABASE " + DbName + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [" + DbName + @"];
CREATE DATABASE " + DbName;
                con.Open();
                SqlConnection.ClearPool(con);
                con.ChangeDatabase("master");
                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, con);
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void RunScript(string dbName, string script)
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["MethodImmoContext"].ConnectionString.Split(new string[] { "connection string=", "\"" }, StringSplitOptions.RemoveEmptyEntries).Last();

            var statements = SplitSqlStatements(script);


            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();
                conn.ChangeDatabase(dbName);
                foreach (var statement in statements)
                {
                    SqlCommand sqlCommand = new SqlCommand(statement, conn);
                    sqlCommand.ExecuteNonQuery();
                }
                
                conn.Close();
            }
        }

        private static IEnumerable<string> SplitSqlStatements(string sqlScript)
        {
            // Split by "GO" statements
            var statements = Regex.Split(
                    sqlScript,
                    @"^\s*GO\s* ($ | \-\- .*$)",
                    RegexOptions.Multiline |
                    RegexOptions.IgnorePatternWhitespace |
                    RegexOptions.IgnoreCase);

            // Remove empties, trim, and return
            return statements
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim(' ', '\r', '\n'));
        }

        public static void CreateEmptyViewModels()
        {
            string basePath = @"D:\Projects\MethodImmo\MethodImmo.Services\ViewModels";
            File.WriteAllText(Path.Combine(basePath, @"Immeuble\new.json"), JsonSerializationTool<object>.SerializeAllTree(new Immeuble() { Adresses = new List<AdressePostale>() { new AdressePostale() } }));
            File.WriteAllText(Path.Combine(basePath, @"Lot\new.json"), JsonSerializationTool<object>.SerializeAllTree(new Lot()));
            File.WriteAllText(Path.Combine(basePath, @"CoordonneesDeContact\new.json"), JsonSerializationTool<object>.SerializeAllTree(new CoordonneesDeContact()));
            File.WriteAllText(Path.Combine(basePath, @"AdressePostale\new.json"), JsonSerializationTool<object>.SerializeAllTree(new AdressePostale()));
            File.WriteAllText(Path.Combine(basePath, @"Individu\new.json"), JsonSerializationTool<object>.SerializeAllTree(new Individu()));

        }
        public static void CreateDataSet()
        {
            Individu chantal = new Individu();
            chantal.Nom = "Vinsot";
            chantal.Prenom = "Chantal";
            chantal.DateDebut = new DateTime(1950, 3, 11);


            Individu eva = new Individu();
            eva.Nom = "Vinsot";
            eva.Prenom = "Eva";
            eva.DateDebut = new DateTime(1983, 12, 19);


            Individu gildas = new Individu();
            gildas.Nom = "Vinsot";
            gildas.Prenom = "Gildas";
            gildas.DateDebut = new DateTime(1981, 11, 28);


            GroupeDeRepartition grp = new GroupeDeRepartition();
            grp.Personnes.Add(gildas);
            grp.Nom = "Propriétaire";

            GroupeDeRepartition grp2 = new GroupeDeRepartition();
            grp2.Personnes.Add(chantal);
            grp2.Nom = "Propriétaire";


            Immeuble flandrin = new Immeuble();
            flandrin.Nom = "Flandrin";
            flandrin.Adresses.Add(new AdressePostale() { Rue = "70 boulevard Flandrin", Pays = "France", CodePostal = "75116", Ville = "Paris" });
            flandrin.Lots.Add(new Lot() { Nom = "Escalier B 3eme étage", Proprietaires = grp, TypeDeLot = TypeDeLot.Appartement });

            Immeuble hugo = new Immeuble();
            hugo.Nom = "Victor Hugo";
            hugo.Adresses.Add(new AdressePostale() { Rue = "96 avenue Victor Hugo", Pays = "France", CodePostal = "75116", Ville = "Paris" });
            hugo.Lots.Add(new Lot() { Nom = "4eme étage droite", Proprietaires = grp2, TypeDeLot = TypeDeLot.Appartement });

            try
            {
                using (var context = new MethodImmoContext())
                {
                    context.ImmeubleSet.Add(flandrin);
                    context.ImmeubleSet.Add(hugo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
