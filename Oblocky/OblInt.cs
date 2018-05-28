using System;

namespace Oblocky
{
    public class OblInt : OblConstNumber
    {
        public OblInt() : base() { }
        public OblInt(int num) : base(num) { }

        protected override Type ValueType { get => typeof(int); }

        public static implicit operator OblInt(OblDouble value) => new OblInt((int)(value.Value));
    }
}
