namespace MethodImmo.Models
{
    using System.Collections.Generic;

    public  class Entreprise : Personne
    {
        public List<GroupeDePersonnes> SousGroupes { get; set; }
    }
}
