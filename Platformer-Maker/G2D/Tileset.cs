using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer_Maker.G2D
{
    class Tileset
    {
        public Tileset(Texture2D tilesetTextre, int width, int height, int tileDimensions)
        {
            TilesetTexture = tilesetTextre;
            Width = width;
            Height = height;
            TileDimensions = tileDimensions;
        }

        public Texture2D TilesetTexture { get; }

        public int Width { get; }

        public int Height { get; }

        public int TileDimensions { get; }

        /// <summary>
        /// Get a tile by it's id.
        /// By default, the id of a tile is 
        /// it's horizontal position
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Texture2D GetTile(int id)
        {
            int x = 0;
            int y = 0;
            for(int i = 0; i < id; i++)
            {
                x++;
                if(i != 0 && (i + 1) % Width == 0)
                {
                    y++;
                    x = 0;
                }
            }

            return GetTile(x, y);
        }

        /// <summary>
        /// Get a tile at a specific coordinate.
        /// The coordinates are measured in
        /// the number of tiles.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Texture2D GetTile(int x, int y)
        {
            return GetTile(new Rectangle(x, y , 1, 1));
        }
        
        /// <summary>
        /// Gets multiple tiles that fit the supplied rectangle
        /// and makes it into a single texture.
        /// Eeach unit in the suplied rectangle is 
        /// </summary>
        /// <param name="rect">The area of the tileset to get</param>
        /// <returns></returns>
        public Texture2D GetTile(Rectangle rect)
        {
            rect.Width  = (rect.Width) * TileDimensions;
            rect.Height = (rect.Height) * TileDimensions;
            rect.X *= TileDimensions;
            rect.Y *= TileDimensions;

            int dimensions = rect.Width * rect.Height * (TileDimensions ^ 2);
            Color[] tileData = new Color[dimensions];

            TilesetTexture.GetData<Color>(0, rect, tileData, 0, dimensions);

            Texture2D tile = new Texture2D(TilesetTexture.GraphicsDevice, rect.Width, rect.Height);
            tile.SetData<Color>(tileData);

            return tile;
        }
    }
}
