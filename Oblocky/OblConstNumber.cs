using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public abstract class OblConstNumber : OblNumber
    {
        public OblConstNumber()
        {
            _value = 0;
        }

        public OblConstNumber(ValueType num)
        {
            _value = num;
        }


        public override dynamic Value
        {
            get => _value;
        }


        public void SetValue(object value)
        {
            if (value.GetType() == ValueType)
                _value = value;
            else
                throw new Exception("Error!");
        }
    }
}
