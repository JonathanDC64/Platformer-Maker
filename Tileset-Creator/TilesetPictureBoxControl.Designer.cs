namespace Tileset_Creator
{
	partial class TilesetPictureBoxControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.TilesetPictureBox = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TilesetPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.TilesetPictureBox);
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(249, 249);
			this.panel1.TabIndex = 0;
			// 
			// TilesetPictureBox
			// 
			this.TilesetPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TilesetPictureBox.Location = new System.Drawing.Point(3, 3);
			this.TilesetPictureBox.Name = "TilesetPictureBox";
			this.TilesetPictureBox.Size = new System.Drawing.Size(241, 241);
			this.TilesetPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.TilesetPictureBox.TabIndex = 7;
			this.TilesetPictureBox.TabStop = false;
			this.TilesetPictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.TilesetPictureBox_LoadCompleted);
			this.TilesetPictureBox.Click += new System.EventHandler(this.TilesetPictureBox_Click);
			this.TilesetPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.TilesetPictureBox_Paint);
			// 
			// TilesetPicutreBoxControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "TilesetPicutreBoxControl";
			this.Size = new System.Drawing.Size(256, 256);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TilesetPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox TilesetPictureBox;
	}
}
