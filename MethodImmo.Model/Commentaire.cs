using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Commentaire
    {
        public DateTime Creation;
        public string Contenu;
        Individu Auteur;
    }
}