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

        public Texture2D GetTile(int id)
        {
            int dimensions = TileDimensions * TileDimensions;
            Color[] tileData = new Color[dimensions];

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

            Rectangle sourceRectanlge = new Rectangle(x * TileDimensions, y * TileDimensions, TileDimensions, TileDimensions);

            TilesetTexture.GetData<Color>(0, sourceRectanlge, tileData, 0, dimensions);

            Texture2D tile = new Texture2D(TilesetTexture.GraphicsDevice, TileDimensions, TileDimensions);
            tile.SetData<Color>(tileData);

            return tile;
        }
    }
}
