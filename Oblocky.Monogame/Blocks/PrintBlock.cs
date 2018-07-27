using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Oblocky.Monogame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oblocky
{
    public class PrintBlock : Monogame.IDrawable, IBlock
    {
        public IBlock NextBlock { get; set; }

        public override Rectangle Collision
        {
            get => new Rectangle(Position, new Point(150, 30));
        }

        public Action<string> Handler = (s) => Console.WriteLine(s);
        public List<Expression> Contents = new List<Expression>();

        private readonly Texture2D texture;

        public PrintBlock()
        {
            texture = new Texture2D(Game1.graphicsDevice, 1, 1);
            var data = new Color[] { Color.White };
            texture.SetData(data);
        }

        public void Execute()
        {
            Handler(string.Join(string.Empty, Contents.Select(x => x.Value.ToString())));
            NextBlock?.Execute();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(Position - new Point(2, 2), new Point(154, 34)), Color.Black);
            spriteBatch.Draw(texture, new Rectangle(Position, new Point(150, 30)), Color.White);
        }

        protected override void update()
        {
            
        }
    }
}