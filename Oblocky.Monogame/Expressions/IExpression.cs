using Oblocky.Monogame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public abstract class IExpression : IDrawable, IObject
    {
        public abstract object Value { get; }
        public virtual new string ToString() => Value.ToString();
    }
}
