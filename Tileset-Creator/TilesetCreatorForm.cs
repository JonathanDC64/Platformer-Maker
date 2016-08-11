using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tileset_Creator
{
    public partial class TilesetCreatorForm : Form
    {
        OpenFileDialog imageSelectDialog;
        int TileWidth;
        int TileHeight;
		int ZoomLevel;
		Image imgOriginal;
		Color GridColor;

        public TilesetCreatorForm()
        {
            InitializeComponent();
            imageSelectDialog = new OpenFileDialog();
            imageSelectDialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
            imageSelectDialog.Title = "Select a tilset Image";

            TileWidth   = (int)TileWidthTextBox.Value;
            TileHeight  = (int)TileHeightTextBox.Value;

			ZoomLevel = ZoomTracker.Value;

            TilesetPictureBox.Paint += TilesetPictureBox_Paint;

			GridColor = Color.Black;

			this.DoubleBuffered = true;
		}

        private void TilesetPictureBox_Paint(object sender, PaintEventArgs e)
        {
			DrawGrid(e);
		}

		private void DrawGrid(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			
			Pen pen = new Pen(GridColor, ZoomLevel);
			Point p1 = new Point(0,0), p2 = new Point(0,0);
			int ImageWidth = TilesetPictureBox.Image == null ? TilesetPictureBox.Width : TilesetPictureBox.Image.Width;// TilesetPictureBox.Image.Width;
			int ImageHeight = TilesetPictureBox.Image == null ? TilesetPictureBox.Height : TilesetPictureBox.Image.Height;// TilesetPictureBox.Image.Height;

			//vertical lines
			for (int i = 0; i < ImageWidth; i++)
			{
				if(i != 0 && i % (TileWidth * ZoomLevel) == 0)
				{
					p1.X = i;
					p1.Y = 0;

					p2.X = i;
					p2.Y = ImageHeight;
					graphics.DrawLine(pen, p1, p2);
				}
			}

			//horizontal lines
			for (int i = 0; i < ImageHeight; i++)
			{
				if (i != 0 && i % (TileHeight * ZoomLevel) == 0)
				{
					p1.X = 0;
					p1.Y = i;

					p2.X = ImageWidth;
					p2.Y = i;
					graphics.DrawLine(pen, p1, p2);
				}
			}
		}

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if(imageSelectDialog.ShowDialog() == DialogResult.OK)
            {
                string location = imageSelectDialog.InitialDirectory + imageSelectDialog.FileName;
                FileLocationTextBox.Text = location;
                SetTilesetImage(location);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
			SetTilesetImage(FileLocationTextBox.Text);
		}

        private void TileWidthTextBox_ValueChanged(object sender, EventArgs e)
        {
			UpdateTileDimesions();
		}

        private void TileHeightTextBox_ValueChanged(object sender, EventArgs e)
        {
			UpdateTileDimesions();
		}

        private void SetTilesetImage(string src)
        {
            TilesetPictureBox.ImageLocation = src;
			ZoomTracker.Value = 2;
			UpdateImageZoom();
		}

		private void UpdateTileDimesions()
		{
			TileWidth = (int)TileWidthTextBox.Value;
			TileHeight = (int)TileHeightTextBox.Value;
			TilesetPictureBox.Refresh();
		}

		private void ZoomTracker_ValueChanged(object sender, EventArgs e)
		{
			UpdateImageZoom();
		}

		private void UpdateImageZoom()
		{
			ZoomLevel = ZoomTracker.Value;
			ZoomLabel.Text = (ZoomLevel) * 50 + "%";
			TilesetPictureBox.Image = null;
			TilesetPictureBox.Image = PictureBoxZoom(imgOriginal, new Size(ZoomLevel, ZoomLevel));
		}

		private Image PictureBoxZoom(Image img, Size size)
		{
			if(img != null)
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

		private void TilesetPictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			imgOriginal = TilesetPictureBox.Image;
			UpdateImageZoom();
		}

		private void GridColorButton_Click(object sender, EventArgs e)
		{
			if(GridColorDialog.ShowDialog() == DialogResult.OK)
			{
				GridColor = GridColorDialog.Color;
				TilesetPictureBox.Refresh();
			}
		}
	}
}
