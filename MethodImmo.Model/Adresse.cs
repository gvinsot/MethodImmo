using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Adresse
    {
        public long Id;
        public List<string> AdressesPhysiques;
        public List<string> AdressesElectroniques;
        public List<string> NumerosDeTelephones;

        public IQueryable<Commentaire> Commentaires;
        public IQueryable<Anomalie> Anomalies;
    }
}