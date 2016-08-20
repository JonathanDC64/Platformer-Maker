using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tileset_Creator
{
	public class TilesetGrid
	{
		public int TileWidth { get; set; }
		public int TileHeight { get; set; }

		public int GridWidth { get; set; }
		public int GridHeight { get; set; }

		public Color GridColor { get; set; }

		public bool[,] GridCells { get; set; }

		public TilesetGrid(int tileWidth, int tileHeight, int gridWidth, int gridHeight)
		{
			TileWidth = tileWidth;
			TileHeight = tileHeight;
			GridWidth = gridWidth;
			GridHeight = gridHeight;
			GridColor = Color.Black;
			UpdateGridCells();
		}

		public void DrawGrid(Graphics graphics, int zoomLevel = 1)
		{
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Brush brush = new SolidBrush(Color.FromArgb(150, 0, 0, 255));
			Pen pen = new Pen(GridColor, (float)zoomLevel);
			
			Point p1 = new Point(0, 0), p2 = new Point(0, 0);

			int width = GridWidth * TileWidth * zoomLevel;
			int height = GridHeight * TileHeight * zoomLevel;

			//selected cells
			for (int i = 0; i < GridHeight; i++)
			{
				for (int j = 0; j < GridWidth; j++)
				{
					if (GridCells[i, j])
					{
						Rectangle rect = new Rectangle(j * TileWidth * zoomLevel, i * TileHeight * zoomLevel, TileWidth * zoomLevel, TileHeight * zoomLevel);
						graphics.FillRectangle(brush, rect);
					}
				}
			}

			//vertical
			for (int i = 0; i < width; i+= TileWidth * zoomLevel)
			{
				p1.X = i;
				p1.Y = 0;

				p2.X = i;
				p2.Y = height;
				graphics.DrawLine(pen, p1, p2);
			}

			//horizontal
			for (int i = 0; i < height; i+= TileHeight * zoomLevel)
			{
				p1.X = 0;
				p1.Y = i;

				p2.X = width;
				p2.Y = i;
				graphics.DrawLine(pen, p1, p2);
			}
		}

		public void UpdateGridCells()
		{
			GridCells = new bool[GridHeight, GridWidth];
		}

		public void ToggleGridCell(int x, int y, int zoomLevel = 1)
		{
			x = (x / (TileWidth * zoomLevel));
			y = (y / (TileHeight * zoomLevel));
			GridCells[y,x] = !GridCells[y,x];
		}
	}
}
