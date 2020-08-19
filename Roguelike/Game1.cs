using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Scenes;
using Roguelike.Utils;
using System;

namespace Roguelike
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        // Grid : 48px x 27px


        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static ContentManager Mycontent;
        public static Camera Camera;
        public static int Scale;

        public SceneManager test;
        RenderTarget2D nativeRenderTarget;
        KeyboardState lastState;



        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Graphics.PreferredBackBufferWidth = 960; Graphics.PreferredBackBufferHeight = 540;
            Mycontent = this.Content;
            Camera = new Camera();
            nativeRenderTarget = new RenderTarget2D(GraphicsDevice, 960, 540);
            Scale = 1;




            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            test = new SceneManager();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            test.Update();

            //Camera.CenterOrigin();
            KeyboardState state = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            Vector2 mousePosition = new Vector2(mouse.Position.X, mouse.Position.Y);

            if (state.IsKeyDown(Keys.Right))
                Camera.X += 10;
            if (state.IsKeyDown(Keys.Left))
                Camera.X -= 10;
            if (state.IsKeyDown(Keys.Up))
                Camera.Y -= 10;
            if (state.IsKeyDown(Keys.Down))
                Camera.Y += 10;
            if (state.IsKeyDown(Keys.A))
                Camera.Zoom -= 0.01f;
            if (state.IsKeyDown(Keys.Z))
                Camera.Zoom += 0.01f;
            if (state.IsKeyDown(Keys.U))
                Camera.Angle -= 0.1f;
            if (state.IsKeyDown(Keys.I))
                Camera.Angle += 0.1f;
            if (state.IsKeyDown(Keys.L) && !lastState.IsKeyDown(Keys.L))
            {
                if (Scale == 1)
                {
                    Graphics.PreferredBackBufferWidth = 1920;
                    Graphics.PreferredBackBufferHeight = 1080;
                    Scale = 2;
                    Graphics.ToggleFullScreen();
                }
                else
                {
                    Graphics.PreferredBackBufferWidth = 960;
                    Graphics.PreferredBackBufferHeight = 540;
                    Scale = 1;
                    Graphics.ToggleFullScreen();
                }

            }

            lastState = state;


            // TODO: Add your update logic here

            Console.WriteLine(Camera.ToString());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(nativeRenderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Camera.Matrix);

            test.Render();
            SpriteBatch.End();


            GraphicsDevice.SetRenderTarget(null);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            Rectangle actualScreenRectangle = new Rectangle(0, 0, Scale * 960, Scale * 540);
            SpriteBatch.Draw(nativeRenderTarget, null, actualScreenRectangle);
            SpriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
