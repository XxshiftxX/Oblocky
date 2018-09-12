using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class VariableExpression : Expression
    {
        public string Name;
        public override object Value => VariableManager.Inst[Name];
    }
}
