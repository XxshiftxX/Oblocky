using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky.Monogame
{
    enum SnapType
    {
        Func, Expression
    }

    struct SnapCollision
    {
        public Rectangle Collision { get; set; }
        public readonly SnapType SnapType;

        public static implicit operator Rectangle(SnapCollision s) => s.Collision;
    }
}
