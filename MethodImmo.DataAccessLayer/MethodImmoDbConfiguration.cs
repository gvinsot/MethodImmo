
using MethodImmo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.DataAccessLayer
{
 internal sealed class MethodImmoDbConfiguration : DbMigrationsConfiguration<MethodImmoDb>
    {
        public MethodImmoDbConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MethodImmoDb context)
        {
            context.Immeubles.Add(new Immeuble()
            {
                Label = "70 bd Flandrin",
            });
        }
    }
}
