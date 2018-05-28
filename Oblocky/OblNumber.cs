using System;

namespace Oblocky
{
    public abstract class OblNumber : IObject
    {
        protected dynamic _value;

        protected abstract Type ValueType { get; }
        public abstract dynamic Value { get; }

        public static OblNumber operator +(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value + num2.Value);
        public static OblNumber operator -(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value - num2.Value);
        public static OblNumber operator *(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value * num2.Value);
        public static OblNumber operator /(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value / num2.Value);
        public static OblNumber operator %(OblNumber num1, OblNumber num2) => ChangeNumToOblNumber(num1.Value % num2.Value);

        //public static implicit operator OblNumber(OblVariable v) => ChangeNumToOblNumber(v.Value);

        public override string ToString() => Value.ToString();

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
}
