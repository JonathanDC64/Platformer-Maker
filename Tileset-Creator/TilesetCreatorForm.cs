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
using Platformer_Maker.Models;
using System.Web.Script.Serialization;
namespace Tileset_Creator
{
    public partial class TilesetCreatorForm : Form
    {
        private OpenFileDialog imageSelectDialog;
       
		enum State
		{
			SETTING_UP,
			READY,
			SELECTING_TILES,
		}

        public TilesetCreatorForm()
        {
            InitializeComponent();
            imageSelectDialog = new OpenFileDialog();
            imageSelectDialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
            imageSelectDialog.Title = "Select a tilset Image";

			TilesetPicutreBox.TileWidth = (int)TileWidthTextBox.Value;
			TilesetPicutreBox.TileHeight = (int)TileHeightTextBox.Value;
			TilesetPicutreBox.ZoomLevel = ZoomTracker.Value;

			this.DoubleBuffered = true;
		}

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if(imageSelectDialog.ShowDialog() == DialogResult.OK)
            {
                string location = imageSelectDialog.InitialDirectory + imageSelectDialog.FileName;
                FileLocationTextBox.Text = location;
				SetImage(location);
			}
		}

		private void SetImage(string src)
		{
			ZoomTracker.Value = TilesetPicutreBox.ZoomLevel = 1;
			TilesetPicutreBox.SetTilesetImage(src);
		}

		private void LoadButton_Click(object sender, EventArgs e)
        {
			SetImage(FileLocationTextBox.Text);
		}

		private void UpdateTileDimesions()
		{
			TilesetPicutreBox.UpdateTileDimesions((int)TileWidthTextBox.Value, (int)TileHeightTextBox.Value);
		}


		private void TileWidthTextBox_ValueChanged(object sender, EventArgs e)
        {
			UpdateTileDimesions();
		}

        private void TileHeightTextBox_ValueChanged(object sender, EventArgs e)
        {
			UpdateTileDimesions();
		}



		private void ZoomTracker_ValueChanged(object sender, EventArgs e)
		{
			UpdateImageZoom();
		}

		private void UpdateImageZoom()
		{
			TilesetPicutreBox.ZoomLevel = ZoomTracker.Value;
			ZoomLabel.Text = (TilesetPicutreBox.ZoomLevel) + "X";
			TilesetPicutreBox.UpdateImageZoom();
		}

		private void GridColorButton_Click(object sender, EventArgs e)
		{
			if (GridColorDialog.ShowDialog() == DialogResult.OK)
			{
				GridColorButton.ForeColor = Color.FromArgb(~GridColorDialog.Color.ToArgb());
				TilesetPicutreBox.grid.GridColor = GridColorButton.BackColor = GridColorDialog.Color;
				TilesetPicutreBox.Refresh();
			}
		}
	}
}
