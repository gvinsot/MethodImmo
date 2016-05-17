using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Model
{
    public class Employees : GroupeDePersonnes
    {
        //public long? EntrepriseId { get; set; }
        //[ForeignKey("EntrepriseId")]
        [InverseProperty("EmployeesGroups")]
        public virtual Entreprise Entreprise { get; set; }
    }
}
