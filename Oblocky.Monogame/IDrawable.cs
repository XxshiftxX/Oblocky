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
        public string name;
        public Point Position;
        public int Layer = 0;
        public bool IsMoving;
        public Point ClickPosition;
        public bool IsSnapping = false;

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
                    bool snapFlag = false;
                    foreach (var obj in Game1.Objects)
                    {
                        // 본인에게 스냅 불가
                        if (obj == this)
                            continue;

                        foreach(var col in obj.SnapCollisions)
                        {
                            if (col.IsSnappable(this) && col.Collision.Contains(Game1.MouseState.Position))
                            {
                                Position = col.SnapPoint;
                                col.ApplySnap(this);
                                snapFlag = true;
                                IsSnapping = true;
                            }
                        }
                    }

                    if (!snapFlag)
                    {
                        Position = Game1.MouseState.Position - ClickPosition;
                        IsSnapping = false;
                    }
                }
            }

            update();
        }

        protected abstract void update();
    }
}
