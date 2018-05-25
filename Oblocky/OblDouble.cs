using System;

namespace Oblocky
{
    public class OblDouble : OblNumber
    {
        public OblDouble() : base() { }
        public OblDouble(double num) : base(num) { }

        protected override Type ValueType { get => typeof(double); }

        public static implicit operator OblDouble(OblInt value) => new OblDouble((double)(value.Value));
    }
}
