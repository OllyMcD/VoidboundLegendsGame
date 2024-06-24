using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace TopDownGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Player and Enemy
        private Player _player;
        private Enemy _enemy;

        // Map
        private Map _map;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize map
            _map = new Map(_graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load player animations
            var playerAnimations = new Dictionary<string, Texture2D>
        {
            { "idle", Content.Load<Texture2D>("WarriorIdle") }, // Assuming the whole sprite sheet is used for idle
            { "walk", Content.Load<Texture2D>("WarriorWalk") } // Assuming the same sprite sheet is used for walk
        };

            // Load enemy animations
            var enemyAnimations = new Dictionary<string, Texture2D>
        {
            { "idle", Content.Load<Texture2D>("GoblinIdle") },
            { "walk", Content.Load<Texture2D>("GoblinWalk") }
        };

            // Initialize player and enemy
            //startPosition, int rows, int columns, float speed, float scale
            _player = new Player(playerAnimations, new Vector2(100, 100), 1, 1, 5f, 4.0f); // Adjust the rows and columns as per the sprite sheet
            _enemy = new Enemy(enemyAnimations, new Vector2(300, 300), 1, 1, 2.5f);

            // Load map content
            Texture2D tileTexture = Content.Load<Texture2D>("GrassTexture");
            _map.LoadContent(tileTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            InputHandling.Update();

            _player.Update(gameTime);
            _enemy.Update(gameTime, _player.Position);

            // Example collision check between player and enemy
            if (CollisionDetection.PlayerEnemyCollision(_player, _enemy))
            {
                // Handle collision logic here
            }
            Thread.Sleep(5);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw the map
            _map.Draw(_spriteBatch);

            // Draw the player and enemy
            _player.Draw(_spriteBatch);
            _enemy.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}









