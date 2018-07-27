using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class ConstExpression : Expression
    {
        private object _value;

        public override object Value => _value;
        public override string ToString() => Value.ToString();

        public void SetValue(object o)
        {
            _value = o;
        }
    }
}
