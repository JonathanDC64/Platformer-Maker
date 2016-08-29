using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.GameObjects;
using Platformer_Maker.Models;
using System.Collections.Generic;

namespace Platformer_Maker.G2D
{
    public class Tileset
    {
        public Tileset(Models.Tileset tilesetData)
        {
			TilesetData = tilesetData;
			Game.AddTexture2D(TilesetData.FileName);
			TilesetTexture = Game.textures2D[TilesetData.FileName][0];
		}
		
		public Models.Tileset TilesetData { get; set; }


		private Texture2D TilesetTexture { set;  get; }

		/// <summary>
		/// Unloads the texture data of the tileset
		/// </summary>
		public void Unload()
		{
			Game.RemoveTexture2D(TilesetData.FileName);
			TilesetTexture = null;
		}

        /// <summary>
        /// Get a tile by it's id.
        /// it's horizontal position
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Texture2D[] GetTile(GameObjectID id)
        {
			List<Texture2D> tiles = new List<Texture2D>();
            for(int i = 0; i < TilesetData.Tiles.Length; i++)
			{
				TileInfo tile = TilesetData.Tiles[i];
				if (tile.ID == id)
				{
					Vector4[] tileCoordinates = tile.TileCoordinates;
					for (int j = 0; j < tileCoordinates.Length; j++)
					{
						tiles.Add(
							GetTile(
								new Rectangle(
									(int)tileCoordinates[j].X, (int)tileCoordinates[j].Y, 
									(int)tileCoordinates[j].Z, (int)tileCoordinates[j].W
								)
							)
						);
					}
					break;
				}
			}

			return tiles.ToArray();
        }
        
        /// <summary>
        /// Gets multiple tiles that fit the supplied rectangle
        /// and makes it into a single texture.
        /// Eeach unit in the suplied rectangle is 
        /// </summary>
        /// <param name="rect">The area of the tileset to get</param>
        /// <returns></returns>
        private Texture2D GetTile(Rectangle rect)
        {
            rect.Width  = (rect.Width - rect.X + 1)  * TilesetData.TileWidth;
            rect.Height = (rect.Height - rect.Y + 1) * TilesetData.TileHeight;
            rect.X *= TilesetData.TileWidth;
            rect.Y *= TilesetData.TileHeight;

			int dimensions = rect.Width * rect.Height * (TilesetData.TileWidth * TilesetData.TileHeight);
            Color[] tileData = new Color[dimensions];

            TilesetTexture.GetData<Color>(0, rect, tileData, 0, dimensions);

            Texture2D tile = new Texture2D(TilesetTexture.GraphicsDevice, rect.Width, rect.Height);
            tile.SetData<Color>(tileData);

            return tile;
        }
    }
}
