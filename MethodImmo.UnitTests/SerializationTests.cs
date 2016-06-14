using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Mid.Tools;
using Newtonsoft.Json;

namespace MethodImmo.UnitTests
{
    [TestClass]
    public class SerializationTests
    {
        
        public class Toto
        {
            public string Name = "bla";
            public int Age = 12;
            public string Adresse = "70 boulevard Flandrin";
            public CompteEnBanque Compte = new CompteEnBanque();
            //public List<int> Values = new List<int>() { 1, 2, 3, 4, 5, 6 };

            public List<CompteEnBanque> AutresComptes = new List<CompteEnBanque>() { new CompteEnBanque(), new CompteEnBanque() };
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


        [TestMethod]
        public void TestSerialization()
        {
            Toto toSerialize = new Toto();
            var result = JsonSerializationTool<Toto>.SerializeAllTree(toSerialize);
            var comparatif = JsonConvert.SerializeObject(toSerialize);
            Assert.AreEqual(result,comparatif);
        }


        [TestMethod]
        public void TestDeserialization(string serialized)
        {
            var result = JsonSerializationTool<Toto>.Deserialize(serialized);

            Assert.AreEqual(result.AutresComptes.Count, 2);
        }

        [TestMethod]
        public void TestFillAWithB()
        {
            Toto toto1 = new Toto();
            Toto2 toto2 = new Toto2();

            string serializeToto2 = JsonSerializationTool<Toto2>.SerializeAllTree(toto2);

            JsonSerializationTool<object>.FillObject(serializeToto2, toto1);

            string serializedToto1 = JsonSerializationTool<Toto>.SerializeAllTree(toto1);
            Assert.AreEqual(serializeToto2,serializedToto1);
        }

    }
}
