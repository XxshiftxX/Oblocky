using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oblocky.Monogame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Inputs
        public static MouseState MouseState { get; private set; }
        public static KeyboardState KeyState { get; private set; }

        public static bool MouseLeftPress = false;
        public static bool MouseRightPress = false;
        #endregion

        #region System
        public static GraphicsDevice graphicsDevice;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        #endregion

        #region Sprite
        private Texture2D cursorSprite;
        private Texture2D testSprite;
        private Texture2D rect;
        private SpriteFont font;
        #endregion
        
        private TextBox text = new TextBox();

        private List<IDrawable> objects = new List<IDrawable>();
        private Dictionary<Microsoft.Xna.Framework.Input.Keys, bool> isKeyDown = new Dictionary<Microsoft.Xna.Framework.Input.Keys, bool>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 1100;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            graphicsDevice = GraphicsDevice;

            Random r = new Random();
            for(int i = 0; i < 20; i++)
            {
                var temp = new PrintBlock();
                temp.Position = new Point(r.Next(20, 500), r.Next(20, 300));
                objects.Add(temp);
            }

            // Test Block Create
            var a = new PrintBlock();
            a.Position = new Point(10, 20);
            objects.Add(a);
            var b = new PrintBlock();
            b.Position = new Point(30, 80);
            objects.Add(b);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Test Sprite Initial
            testSprite = Content.Load<Texture2D>("sprite");

            // Test Rect Initial
            rect = new Texture2D(GraphicsDevice, 1, 1);
            Color[] data = new Color[] { Color.White };
            rect.SetData(data);

            // Test Font Initial
            font = Content.Load<SpriteFont>("font");

            cursorSprite = Content.Load<Texture2D>("Cursor");
        }
        
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            MouseState = Mouse.GetState();
            KeyState = Keyboard.GetState();

            #region Mouse
            // MouseClick Left
            if(MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if (!MouseLeftPress)
                {
                    objects.Reverse();

                    IDrawable drawables = null;

                    foreach(var temp in objects)
                    {
                        if(temp.Collision.Contains(MouseState.Position) && (drawables == null || drawables.Layer < temp.Layer))
                        {
                            drawables = temp;
                        }
                    }

                    if(drawables != null)
                    {
                        drawables.ClickPosition = MouseState.Position - drawables.Position;
                        drawables.IsMoving = true;
                        objects.Remove(drawables);
                        objects.Insert(0, drawables);
                    }

                    objects.Reverse();

                    MouseLeftPress = true;
                }
            }
            else
            {
                if (MouseLeftPress) MouseLeftPress = false;
            }
            #endregion

            #region Keyboard
            foreach (var key in KeyState.GetPressedKeys())
            {
                /*
                if (!isKeyDown[key])
                {
                    isKeyDown[key] = false;
                }
                */
            }

            if (KeyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();
            #endregion

            foreach(var obj in objects)
            {
                obj.Update();
            }
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();

            foreach (var obj in objects)
            {
                obj.Draw(spriteBatch);
            }

            spriteBatch.Draw(cursorSprite, new Rectangle(MouseState.Position, new Point(25, 30)), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
