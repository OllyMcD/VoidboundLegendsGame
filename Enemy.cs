using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TopDownGame
{
    public class Enemy
    {
        private AnimatedSprite _animatedSprite;
        public Vector2 Position { get; private set; }
        private float _speed;

        public Enemy(Dictionary<string, Texture2D> animations, Vector2 startPosition, int rows, int columns, float speed)
        {
            _animatedSprite = new AnimatedSprite(animations, rows, columns);
            Position = startPosition;
            _speed = speed;
        }

        public void Update(GameTime gameTime, Vector2 playerPosition)
        {
            // Simple follow player logic
            Vector2 direction = playerPosition - Position;
            if (direction.Length() > 0)
                direction.Normalize();
            Position += direction * _speed;

            // Set moving animation
            _animatedSprite.SetAnimation("walk"); // Assume "walk" is the moving animation
            _animatedSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animatedSprite.Draw(spriteBatch, Position, 2f); // Adjust scale as needed
        }

        // Accessor for AnimatedSprite dimensions
        public int Width => _animatedSprite.CurrentFrameWidth;
        public int Height => _animatedSprite.CurrentFrameHeight;
    }
}







