
namespace MethodImmo.Models
{

    public class CleDeRepartition
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public long Tantiemes { get; set; }

        public Lot Lot { get; set; }
    }
}
