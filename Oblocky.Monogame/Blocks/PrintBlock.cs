using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Oblocky.Monogame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Oblocky
{
    public class PrintBlock : IBlock
    {
        private IBlock nextBlock;
        public IBlock NextBlock
        {
            get => nextBlock;
            set
            {
                value = nextBlock;
                Resize();
            }
        }

        private Point size = new Point(200, 40);

        public override Rectangle Collision => new Rectangle(Position, size);

        public override SnapCollision[] SnapCollisions => new SnapCollision[] 
        {
            // 블럭 하단 (NextBlock) 스냅
            new SnapCollision(
                new Point(Position.X, Position.Y + size.Y),
                new Rectangle(new Point(Position.X, Position.Y + size.Y - 15), new Point(size.X, 30)),
                SnapType.Func)
        };

        public Action<string> Handler = (s) => Debug.WriteLine(s);
        public List<IExpression> Contents = new List<IExpression>();

        private readonly Texture2D texture;

        public PrintBlock()
        {
            texture = new Texture2D(Game1.graphicsDevice, 1, 1);
            var data = new Color[] { Color.White };
            texture.SetData(data);
        }

        public override void Execute()
        {
            Handler(string.Join(string.Empty, Contents.Select(x => x.Value.ToString())));
            NextBlock?.Execute();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(Position - new Point(2, 2), size + new Point(4, 4)), Color.Black);
            spriteBatch.Draw(texture, new Rectangle(Position, size), Color.White);
        }

        protected override void update()
        {
            
        }


        private void Resize()
        {

        }
    }
}