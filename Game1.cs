using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Xml;

namespace RPG_OOMS_Shawn_Bernard
{
    /// <summary>
    /// This is my messy RPG game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Scene _scene;
        private Entity player;
        private Entity enemy;
        private Map map;

        /// <summary>
        /// This will add anything needed for the game when a new game1 is made
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _scene = new Scene();
            _scene.Awake();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            _scene.Start();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            Texture2D playerTexture = Content.Load<Texture2D>("Player");
            Texture2D wallTexture = Content.Load<Texture2D>("Wall");
            Texture2D groundTexture = Content.Load<Texture2D>("Ground");
            Texture2D exitTexture = Content.Load<Texture2D>("Exit");

            // Creating my player and map
            player = new Entity();
            map = new Map();
            player.AddTexture(playerTexture);
            map.AddTexture(wallTexture,groundTexture);

            //Adding my game objects to my scene game object list
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
