using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class VariableManager : Dictionary<string, (Type type, object value)>
    {
        public static VariableManager inst = new VariableManager();

        private VariableManager() { }
    }
}
