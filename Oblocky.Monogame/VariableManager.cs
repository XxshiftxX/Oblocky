using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class VariableManager
    {
        private Dictionary<string, object> dict = new Dictionary<string, object>();
        private static VariableManager inst;

        public static VariableManager Inst
        {
            get
            {
                if (inst == null)
                    inst = new VariableManager();

                return inst;
            }
        }

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
