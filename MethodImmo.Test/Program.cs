using MethodImmo.DAL;
using Mid.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = TestSerialization();

            TestDeserialization(result);

            TestFillAWithB();

            CreateDataSet();

            Console.ReadLine();
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
            flandrin.TotalTantiemes = 1;            
            flandrin.Adresses.Add(new AdressePostale() { Rue = "70 boulevard Flandrin", Pays = "France", CodePostal = "75116", Ville = "Paris" });
            flandrin.Lots.Add(new Lot() { Nom = "Escalier B 3eme étage",Tantiemes=1, Proprietaire = grp });
            
            Immeuble hugo = new Immeuble();
            hugo.Nom = "Victor Hugo";
            hugo.TotalTantiemes = 1;
            hugo.Adresses.Add(new AdressePostale() { Rue = "96 avenue Victor Hugo", Pays = "France", CodePostal = "75116", Ville = "Paris" });
            hugo.Lots.Add(new Lot() { Nom = "4eme étage droite", Tantiemes = 1, Proprietaire = grp2 });
            
            try
            {
                using (var context = new MethodImmoContext())
                {
                    context.ImmeubleSet.Add(flandrin);
                    context.ImmeubleSet.Add(hugo);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public class Toto
        {
            public string Name = "bla";
            public int Age = 12;
            public string Adresse  = "70 boulevard Flandrin";
            public CompteEnBanque Compte = new CompteEnBanque();
            //public List<int> Values = new List<int>() { 1, 2, 3, 4, 5, 6 };

            public List<CompteEnBanque> AutresComptes = new List<CompteEnBanque>() { new CompteEnBanque() , new CompteEnBanque() };
        }


        public class Toto2
        {
            public string Name = "alb";
            public int Age = 24;
            public string Adresse = "162 rue de Longchamps";
            public CompteEnBanque Compte = new CompteEnBanque() { BIC = "2132", IBAN = "231" };
            //public List<int> Values = new List<int>() { 1, 2, 3, 4, 5, 6 };

            public List<CompteEnBanque> AutresComptes = new List<CompteEnBanque>() { new CompteEnBanque() { BIC = "2132", IBAN = "231" }, new CompteEnBanque() { BIC = "2132", IBAN = "231" } };
        }

        public class CompteEnBanque
        {
            public string BIC = "56546549687464";
            public string IBAN = "TYH5646ZEFZEF564ZEFZEF";
        }

        

        public static string TestSerialization()
        {
            Toto toSerialize = new Toto();
            var result = JsonSerializationTool<Toto>.SerializeAllTree(toSerialize);
            var comparatif = JsonConvert.SerializeObject(toSerialize);
            Console.WriteLine(result==comparatif);
            return result;
        }


        public static void TestDeserialization(string serialized)
        {
            var result = JsonSerializationTool<Toto>.Deserialize(serialized);
            
            Console.WriteLine(result.AutresComptes.Count()==2);
        }

        public static void TestFillAWithB()
        {
            Toto toto1 = new Toto();
            Toto2 toto2 = new Toto2();

            string serializeToto2 = JsonSerializationTool<Toto2>.SerializeAllTree(toto2);

            JsonSerializationTool<object>.FillObject(serializeToto2, toto1);

            string serializedToto1 = JsonSerializationTool<Toto>.SerializeAllTree(toto1);
            Console.WriteLine(serializeToto2 == serializedToto1);
        }

    }
}
