using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Tileset_Creator
{
	public partial class TilesetPicutreBoxControl : UserControl
	{
		public TilesetGrid grid;
		public int TileWidth;
		public int TileHeight;
		public int ZoomLevel;
		private Image imgOriginal;
		public TilesetPicutreBoxControl()
		{
			InitializeComponent();
			TileWidth = 16;
			TileHeight = 16;
			grid = new TilesetGrid(TileWidth, TileHeight, TilesetPictureBox.Width / TileWidth, TilesetPictureBox.Height / TileHeight);
		}

		private void TilesetPictureBox_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			grid.DrawGrid(graphics, ZoomLevel);
		}

		public void UpdateTileDimesions(int width, int height)
		{
			TileWidth = grid.TileWidth = width;
			TileHeight = grid.TileHeight = height;
			TilesetPictureBox.Refresh();
		}

		public void SetTilesetImage(string src)
		{
			TilesetPictureBox.ImageLocation = src;
			UpdateImageZoom();
		}

		public void UpdateImageZoom()
		{
			
			TilesetPictureBox.Image = null;
			TilesetPictureBox.Image = PictureBoxZoom(imgOriginal, new Size(ZoomLevel, ZoomLevel));
		}

		private Image PictureBoxZoom(Image img, Size size)
		{
			if (img != null)
			{
				int width = Convert.ToInt32(img.Width * size.Width);
				int height = Convert.ToInt32(img.Height * size.Height);
				Bitmap bm = new Bitmap(img, width, height);

				// This is done to give nearest neighbor scaling
				Graphics graph = Graphics.FromImage(bm);
				graph.InterpolationMode = InterpolationMode.NearestNeighbor;
				graph.SmoothingMode = SmoothingMode.None;
				graph.DrawImage(img, new Rectangle(0, 0, width, height));

				return bm;
			}
			return null;
		}

		public new void Refresh()
		{
			TilesetPictureBox.Refresh();
		}

		private void TilesetPictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			imgOriginal = TilesetPictureBox.Image;
			UpdateImageZoom();
			grid.UpdateGridCells();
		}

		private void TilesetPictureBox_Click(object sender, EventArgs e)
		{
			Point point = ((PictureBox)sender).PointToClient(Cursor.Position);
			Console.WriteLine(string.Format("X: {0} Y: {1}", point.X, point.Y));
			grid.ToggleGridCell(point.X, point.Y, ZoomLevel);
			TilesetPictureBox.Refresh();
		}
	}
}
