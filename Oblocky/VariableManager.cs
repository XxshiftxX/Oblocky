using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    internal class VariableManager
    {
        private readonly Dictionary<string, object> dict = new Dictionary<string, object>();
        private static VariableManager inst;

        public static VariableManager Inst => inst ?? (inst = new VariableManager());

        public object this[string n]
        {
            get => dict[n];
            set
            {
                if (!dict.ContainsKey(n))
                    dict.Add(n, value);
                else
                    dict[n] = value;
            }
        }
    }
}
