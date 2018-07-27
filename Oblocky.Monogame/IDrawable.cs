using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky.Monogame
{
    public abstract class IDrawable
    {
        public Point Position;
        public int Layer = 0;
        public bool IsMoving;
        public Point ClickPosition;

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
                }
            }

            update();
        }

        protected abstract void update();
    }
}
