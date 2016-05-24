using Mid.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.DAL
{
    public static class ContextHelper
    {
        public static void IntegrateWithContext(object toIntegrate, MethodImmoContext context) //, Dictionary<Type, HashSet<string>> inclusions = null, Dictionary<Type, HashSet<string>> exclusions = null, ForEachRecursiveFilterDelegate filter = null)
        {
           ObjectTools.ForEachMemberRecursive(toIntegrate, null, null, null,
                (val, parent, memberInfo, ctxt) =>
                {
                    if (memberInfo.Name == "Id")
                    {
                        //context.attach?
                    }
                }, null);
        }
    }
}
