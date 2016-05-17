using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Entreprise : Personne
    {
        [InverseProperty("Entreprise")]
        public virtual ICollection<Employees> EmployeesGroups { get; set; }

    }
}