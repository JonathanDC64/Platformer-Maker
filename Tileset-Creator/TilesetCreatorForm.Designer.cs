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
			this.GridColorButton = new System.Windows.Forms.Button();
			this.ZoomLabel = new System.Windows.Forms.Label();
			this.ZoomTracker = new System.Windows.Forms.TrackBar();
			this.TileHeightTextBox = new System.Windows.Forms.NumericUpDown();
			this.TileWidthTextBox = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LoadButton = new System.Windows.Forms.Button();
			this.FileLocationTextBox = new System.Windows.Forms.TextBox();
			this.SelectFileButton = new System.Windows.Forms.Button();
			this.GridColorDialog = new System.Windows.Forms.ColorDialog();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.TilesetPicutreBox = new Tileset_Creator.TilesetPicutreBoxControl();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZoomTracker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TileHeightTextBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TileWidthTextBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.GridColorButton);
			this.panel4.Controls.Add(this.ZoomLabel);
			this.panel4.Controls.Add(this.ZoomTracker);
			this.panel4.Controls.Add(this.TileHeightTextBox);
			this.panel4.Controls.Add(this.TileWidthTextBox);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Location = new System.Drawing.Point(12, 438);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(659, 51);
			this.panel4.TabIndex = 2;
			// 
			// GridColorButton
			// 
			this.GridColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.GridColorButton.Location = new System.Drawing.Point(523, 6);
			this.GridColorButton.Name = "GridColorButton";
			this.GridColorButton.Size = new System.Drawing.Size(128, 38);
			this.GridColorButton.TabIndex = 8;
			this.GridColorButton.Text = "Grid Color";
			this.GridColorButton.UseVisualStyleBackColor = true;
			this.GridColorButton.Click += new System.EventHandler(this.GridColorButton_Click);
			// 
			// ZoomLabel
			// 
			this.ZoomLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.ZoomLabel.AutoSize = true;
			this.ZoomLabel.Location = new System.Drawing.Point(286, 19);
			this.ZoomLabel.Name = "ZoomLabel";
			this.ZoomLabel.Size = new System.Drawing.Size(20, 13);
			this.ZoomLabel.TabIndex = 7;
			this.ZoomLabel.Text = "1X";
			// 
			// ZoomTracker
			// 
			this.ZoomTracker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ZoomTracker.Location = new System.Drawing.Point(3, 3);
			this.ZoomTracker.Minimum = 1;
			this.ZoomTracker.Name = "ZoomTracker";
			this.ZoomTracker.Size = new System.Drawing.Size(277, 45);
			this.ZoomTracker.TabIndex = 1;
			this.ZoomTracker.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.ZoomTracker.Value = 1;
			this.ZoomTracker.ValueChanged += new System.EventHandler(this.ZoomTracker_ValueChanged);
			// 
			// TileHeightTextBox
			// 
			this.TileHeightTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.TileHeightTextBox.Location = new System.Drawing.Point(426, 22);
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
			this.TileWidthTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.TileWidthTextBox.Location = new System.Drawing.Point(334, 22);
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
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(423, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tile Height:";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(331, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tile Width:";
			// 
			// LoadButton
			// 
			this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadButton.Location = new System.Drawing.Point(677, 12);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(255, 23);
			this.LoadButton.TabIndex = 2;
			this.LoadButton.Text = "Load";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// FileLocationTextBox
			// 
			this.FileLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FileLocationTextBox.Location = new System.Drawing.Point(108, 12);
			this.FileLocationTextBox.Name = "FileLocationTextBox";
			this.FileLocationTextBox.Size = new System.Drawing.Size(563, 20);
			this.FileLocationTextBox.TabIndex = 1;
			// 
			// SelectFileButton
			// 
			this.SelectFileButton.Location = new System.Drawing.Point(12, 12);
			this.SelectFileButton.Name = "SelectFileButton";
			this.SelectFileButton.Size = new System.Drawing.Size(90, 23);
			this.SelectFileButton.TabIndex = 0;
			this.SelectFileButton.Text = "Select Image";
			this.SelectFileButton.UseVisualStyleBackColor = true;
			this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(677, 41);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(255, 448);
			this.flowLayoutPanel1.TabIndex = 4;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// TilesetPicutreBox
			// 
			this.TilesetPicutreBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TilesetPicutreBox.Location = new System.Drawing.Point(8, 38);
			this.TilesetPicutreBox.Name = "TilesetPicutreBox";
			this.TilesetPicutreBox.Size = new System.Drawing.Size(663, 394);
			this.TilesetPicutreBox.TabIndex = 3;
			// 
			// TilesetCreatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(944, 501);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.TilesetPicutreBox);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.SelectFileButton);
			this.Controls.Add(this.FileLocationTextBox);
			this.Controls.Add(this.LoadButton);
			this.MinimumSize = new System.Drawing.Size(960, 540);
			this.Name = "TilesetCreatorForm";
			this.Text = "Tileset Creator";
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZoomTracker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TileHeightTextBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TileWidthTextBox)).EndInit();
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
		private System.Windows.Forms.Button GridColorButton;
		private System.Windows.Forms.ColorDialog GridColorDialog;
		private TilesetPicutreBoxControl TilesetPicutreBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}

