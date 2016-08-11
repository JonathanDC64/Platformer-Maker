namespace Tileset_Creator
{
    partial class TilesetCreatorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel4 = new System.Windows.Forms.Panel();
			this.ZoomLabel = new System.Windows.Forms.Label();
			this.ZoomTracker = new System.Windows.Forms.TrackBar();
			this.TileHeightTextBox = new System.Windows.Forms.NumericUpDown();
			this.TileWidthTextBox = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LoadButton = new System.Windows.Forms.Button();
			this.FileLocationTextBox = new System.Windows.Forms.TextBox();
			this.SelectFileButton = new System.Windows.Forms.Button();
			this.TilesetPictureBox = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.GridColorButton = new System.Windows.Forms.Button();
			this.GridColorDialog = new System.Windows.Forms.ColorDialog();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZoomTracker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TileHeightTextBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TileWidthTextBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TilesetPictureBox)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.Controls.Add(this.GridColorButton);
			this.panel4.Controls.Add(this.ZoomLabel);
			this.panel4.Controls.Add(this.ZoomTracker);
			this.panel4.Controls.Add(this.TileHeightTextBox);
			this.panel4.Controls.Add(this.TileWidthTextBox);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Location = new System.Drawing.Point(740, 41);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(192, 122);
			this.panel4.TabIndex = 2;
			// 
			// ZoomLabel
			// 
			this.ZoomLabel.AutoSize = true;
			this.ZoomLabel.Location = new System.Drawing.Point(141, 45);
			this.ZoomLabel.Name = "ZoomLabel";
			this.ZoomLabel.Size = new System.Drawing.Size(33, 13);
			this.ZoomLabel.TabIndex = 7;
			this.ZoomLabel.Text = "100%";
			// 
			// ZoomTracker
			// 
			this.ZoomTracker.Location = new System.Drawing.Point(5, 41);
			this.ZoomTracker.Minimum = 2;
			this.ZoomTracker.Name = "ZoomTracker";
			this.ZoomTracker.Size = new System.Drawing.Size(135, 45);
			this.ZoomTracker.TabIndex = 1;
			this.ZoomTracker.TickStyle = System.Windows.Forms.TickStyle.None;
			this.ZoomTracker.Value = 2;
			this.ZoomTracker.ValueChanged += new System.EventHandler(this.ZoomTracker_ValueChanged);
			// 
			// TileHeightTextBox
			// 
			this.TileHeightTextBox.Location = new System.Drawing.Point(101, 16);
			this.TileHeightTextBox.Name = "TileHeightTextBox";
			this.TileHeightTextBox.Size = new System.Drawing.Size(91, 20);
			this.TileHeightTextBox.TabIndex = 5;
			this.TileHeightTextBox.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.TileHeightTextBox.ValueChanged += new System.EventHandler(this.TileHeightTextBox_ValueChanged);
			// 
			// TileWidthTextBox
			// 
			this.TileWidthTextBox.Location = new System.Drawing.Point(6, 16);
			this.TileWidthTextBox.Name = "TileWidthTextBox";
			this.TileWidthTextBox.Size = new System.Drawing.Size(89, 20);
			this.TileWidthTextBox.TabIndex = 4;
			this.TileWidthTextBox.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.TileWidthTextBox.ValueChanged += new System.EventHandler(this.TileWidthTextBox_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(92, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tile Height:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tile Width:";
			// 
			// LoadButton
			// 
			this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadButton.Location = new System.Drawing.Point(740, 12);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(192, 23);
			this.LoadButton.TabIndex = 2;
			this.LoadButton.Text = "Load";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// FileLocationTextBox
			// 
			this.FileLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FileLocationTextBox.Location = new System.Drawing.Point(89, 12);
			this.FileLocationTextBox.Name = "FileLocationTextBox";
			this.FileLocationTextBox.Size = new System.Drawing.Size(645, 20);
			this.FileLocationTextBox.TabIndex = 1;
			// 
			// SelectFileButton
			// 
			this.SelectFileButton.Location = new System.Drawing.Point(8, 12);
			this.SelectFileButton.Name = "SelectFileButton";
			this.SelectFileButton.Size = new System.Drawing.Size(75, 23);
			this.SelectFileButton.TabIndex = 0;
			this.SelectFileButton.Text = "Select File";
			this.SelectFileButton.UseVisualStyleBackColor = true;
			this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
			// 
			// TilesetPictureBox
			// 
			this.TilesetPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TilesetPictureBox.Location = new System.Drawing.Point(3, 3);
			this.TilesetPictureBox.Name = "TilesetPictureBox";
			this.TilesetPictureBox.Size = new System.Drawing.Size(713, 439);
			this.TilesetPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.TilesetPictureBox.TabIndex = 3;
			this.TilesetPictureBox.TabStop = false;
			this.TilesetPictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.TilesetPictureBox_LoadCompleted);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.TilesetPictureBox);
			this.panel1.Location = new System.Drawing.Point(13, 42);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(721, 447);
			this.panel1.TabIndex = 4;
			// 
			// GridColorButton
			// 
			this.GridColorButton.Location = new System.Drawing.Point(3, 92);
			this.GridColorButton.Name = "GridColorButton";
			this.GridColorButton.Size = new System.Drawing.Size(186, 27);
			this.GridColorButton.TabIndex = 8;
			this.GridColorButton.Text = "Grid Color";
			this.GridColorButton.UseVisualStyleBackColor = true;
			this.GridColorButton.Click += new System.EventHandler(this.GridColorButton_Click);
			// 
			// TilesetCreatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(944, 501);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.SelectFileButton);
			this.Controls.Add(this.FileLocationTextBox);
			this.Controls.Add(this.LoadButton);
			this.Name = "TilesetCreatorForm";
			this.Text = "Tileset Creator";
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZoomTracker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TileHeightTextBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TileWidthTextBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TilesetPictureBox)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.Button SelectFileButton;
		private System.Windows.Forms.TextBox FileLocationTextBox;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label ZoomLabel;
		private System.Windows.Forms.TrackBar ZoomTracker;
		private System.Windows.Forms.NumericUpDown TileHeightTextBox;
		private System.Windows.Forms.NumericUpDown TileWidthTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox TilesetPictureBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button GridColorButton;
		private System.Windows.Forms.ColorDialog GridColorDialog;
	}
}

