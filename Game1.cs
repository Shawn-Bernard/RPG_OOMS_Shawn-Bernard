using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;

namespace RPG_OOMS_Shawn_Bernard
{
    /// <summary>
    /// This is my game
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        Scene _scene;
        Player player;
        Map map;

        /// <summary>
        /// This is 
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _scene = new Scene();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //_scene.Start();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            Texture2D playerTexture = Content.Load<Texture2D>("Player");
            Texture2D groundTexture = Content.Load<Texture2D>("Ground");
            Texture2D wallTexture = Content.Load<Texture2D>("Wall");

            // You can now pass these textures to your game objects
            player = new Player(playerTexture);
            map = new Map(wallTexture, groundTexture);

            // Optionally set other objects' textures like the ground or walls
            // Add your objects to the scene
            _scene.AddGameObject(map);
            _scene.AddGameObject(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _scene.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _scene.Draw(_spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
