using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TopDownGame
{
    public class Player
    {
        private AnimatedSprite _animatedSprite;
        public Vector2 Position { get; private set; }
        private float _speed;
        private float _scale;
        private bool isMoving = false;

        public Player(Dictionary<string, Texture2D> animations, Vector2 startPosition, int rows, int columns, float speed, float scale = 20.0f)
        {
            _animatedSprite = new AnimatedSprite(animations, rows, columns);
            Position = startPosition;
            _speed = speed;
            _scale = scale;
        }

        public void Update(GameTime gameTime)
        {
            if (isMoving)
            {
                _animatedSprite.SetAnimation("walk"); // Assume "walk" is the moving animation
            }
            else
            {
                _animatedSprite.SetAnimation("idle"); // Assume "idle" is the idle animation
            }
            var keyboardState = Keyboard.GetState();
            

            // Handle player movement
            Vector2 newPosition = Position;
            if (keyboardState.IsKeyDown(Keys.W))
            {
                newPosition.Y -= _speed;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                newPosition.Y += _speed;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                newPosition.X -= _speed;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                newPosition.X += _speed;
                isMoving = true;
            }

            Position = newPosition;



            // Update the player animation
            _animatedSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animatedSprite.Draw(spriteBatch, Position, _scale);
        }

        // Accessor for AnimatedSprite dimensions
        public int Width => _animatedSprite.CurrentFrameWidth;
        public int Height => _animatedSprite.CurrentFrameHeight;
    }
}










