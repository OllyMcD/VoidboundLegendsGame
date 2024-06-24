using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace TopDownGame
{
    public class AnimatedSprite
    {
        private Dictionary<string, Texture2D> _animations;
        private string _currentAnimation;
        private int _rows;
        private int _columns;
        private int _currentFrame;
        private int _totalFrames;
        private int _frameWidth; // Width of each frame
        private int _frameHeight; // Height of each frame

        public AnimatedSprite(Dictionary<string, Texture2D> animations, int rows, int columns)
        {
            _animations = animations;
            _rows = rows;
            _columns = columns;
            _currentFrame = 0;
            _totalFrames = rows * columns;
            _currentAnimation = null;

            // Assuming all frames have the same dimensions
            _frameWidth = _animations.Values.First().Width / columns;
            _frameHeight = _animations.Values.First().Height / rows;
        }

        public void SetAnimation(string animationName)
        {
            if (_currentAnimation == animationName || !_animations.ContainsKey(animationName))
                return;

            _currentAnimation = animationName;
            _currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (_currentAnimation == null)
                return;

            // Update animation frame based on elapsed time or some other logic
            // For simplicity, I'm incrementing frame here, you may need a more sophisticated logic
            _currentFrame++;
            if (_currentFrame >= _totalFrames)
                _currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float scale)
        {
            if (_currentAnimation == null)
                return;

            Texture2D texture = _animations[_currentAnimation];
            int width = _frameWidth;
            int height = _frameHeight;
            int row = _currentFrame / _columns;
            int column = _currentFrame % _columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * scale), (int)(height * scale));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        // Property to get the width of the current frame
        public int CurrentFrameWidth => _frameWidth;

        // Property to get the height of the current frame
        public int CurrentFrameHeight => _frameHeight;
    }
}










