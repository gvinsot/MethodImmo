using MethodImmo.DAL;
using Mid.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.DatabaseReset
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateEmptyViewModels();
            CreateDataSet();
            Console.ReadLine();
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
