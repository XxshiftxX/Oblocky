using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public interface IObject
    {
        dynamic Value { get; set; }
    }

    public abstract class OblNumber : IObject
    {
        private dynamic _value;
        protected abstract Type ValueType { get; }

        public OblNumber()
        {
            Value = 0;
        }

        public OblNumber(ValueType num)
        {
            Value = num;
        }

        public dynamic Value
        {
            get => _value;
            set
            {
                if (value is ValueType num)
                    _value = value;
                else
                    throw new Exception("Error!");
            }
        }

        public static OblNumber operator +(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value + num2.Value);
        public static OblNumber operator -(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value - num2.Value);
        public static OblNumber operator *(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value * num2.Value);
        public static OblNumber operator /(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value / num2.Value);
        public static OblNumber operator %(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value % num2.Value);

        private static OblNumber ChangeNumToOblNumber(dynamic input)
        {
            switch (input)
            {
                case int num:
                    return new OblInt(num);
                case double num:
                    return new OblDouble(num);
                default:
                    throw new Exception("Error!");
            }
        }
    }

    public class OblInt : OblNumber
    {
        public OblInt() : base() { }
        public OblInt(int num) : base(num) { }

        protected override Type ValueType { get => typeof(int); }

        public static implicit operator OblInt(OblDouble value) => new OblInt((int)(value.Value));
    }

    public class OblDouble : OblNumber
    {
        public OblDouble() : base() { }
        public OblDouble(double num) : base(num) { }

        protected override Type ValueType { get => typeof(double); }

        public static implicit operator OblDouble(OblInt value) => new OblDouble((double)(value.Value));
    }
}
