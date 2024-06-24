using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownGame
{
    public class Map
    {
        private int[,] _map;
        private Texture2D _tileTexture;
        private int _tileSize;
        private GraphicsDeviceManager _graphics;

        public Map(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            _tileSize = 32;

            // Initialize the map with enough tiles to fit the screen
            int width = graphics.PreferredBackBufferWidth / _tileSize;
            int height = graphics.PreferredBackBufferHeight / _tileSize;
            _map = new int[height, width];

            // Simple example map
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _map[y, x] = 1;
                }
            }
        }

        public void LoadContent(Texture2D tileTexture)
        {
            _tileTexture = tileTexture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _map.GetLength(0); y++)
            {
                for (int x = 0; x < _map.GetLength(1); x++)
                {
                    if (_map[y, x] == 1)
                    {
                        spriteBatch.Draw(_tileTexture, new Vector2(x * _tileSize, y * _tileSize), Color.White);
                    }
                }
            }
        }
    }
}



