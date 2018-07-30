using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace Oblocky.Monogame
{
    public abstract class IDrawable
    {
        public Point Position;
        public int Layer = 0;
        public bool IsMoving;
        public Point ClickPosition;

        public abstract SnapCollision[] SnapCollisions { get; }
        public abstract Rectangle Collision { get; } 

        public abstract void Draw(SpriteBatch spriteBatch);

        public void Update()
        {
            if(IsMoving)
            {
                if (Game1.MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
                {
                    IsMoving = false;
                }
                else
                {
                    Position = Game1.MouseState.Position - ClickPosition;

                    foreach (var obj in Game1.Objects)
                    {
                        if (obj == this)
                            continue;

                        foreach(var col in obj.SnapCollisions)
                        {
                            if (col.IsSnappable(this) && col.Collision.Contains(Game1.MouseState.Position))
                                Position = col.SnapPoint;
                        }
                    }
                }
            }

            update();
        }

        protected abstract void update();
    }
}
