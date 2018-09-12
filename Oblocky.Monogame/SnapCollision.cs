using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky.Monogame
{
    public enum SnapType
    {
        Func, Expression
    }

    public struct SnapCollision
    {
        public readonly Rectangle Collision;
        public readonly Point SnapPoint;
        public readonly SnapType SnapType;
        public readonly Action<IDrawable> ApplySnap;

        public static implicit operator Rectangle(SnapCollision s) => s.Collision;

        public SnapCollision(Point snapPoint, Rectangle collision, SnapType snapType, Action<IDrawable> applySnap)
        {
            SnapPoint = snapPoint;
            Collision = collision;
            SnapType = snapType;
            ApplySnap = applySnap;
        }

        public bool IsSnappable(IDrawable block)
        {
            switch(block)
            {
                case IBlock b when SnapType == SnapType.Func:
                    return true;
                case IExpression e when SnapType == SnapType.Expression:
                    return true;
                default:
                    return false;
            }
        }
    }
}
