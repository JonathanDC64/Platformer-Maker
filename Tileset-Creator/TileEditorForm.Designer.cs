namespace Tileset_Creator
{
	partial class TileEditorForm
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.TileEditorPanel = new System.Windows.Forms.Panel();
			this.DoneButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.GridWidtTextBox = new System.Windows.Forms.NumericUpDown();
			this.GridHeightTextBox = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.IDTextBox = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GridWidtTextBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridHeightTextBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IDTextBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.TileEditorPanel);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(258, 258);
			this.panel1.TabIndex = 0;
			// 
			// TileEditorPanel
			// 
			this.TileEditorPanel.Location = new System.Drawing.Point(4, 4);
			this.TileEditorPanel.Name = "TileEditorPanel";
			this.TileEditorPanel.Size = new System.Drawing.Size(249, 249);
			this.TileEditorPanel.TabIndex = 0;
			// 
			// DoneButton
			// 
			this.DoneButton.Location = new System.Drawing.Point(276, 247);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new System.Drawing.Size(84, 23);
			this.DoneButton.TabIndex = 1;
			this.DoneButton.Text = "Done";
			this.DoneButton.UseVisualStyleBackColor = true;
			this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(375, 247);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(84, 23);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// GridWidtTextBox
			// 
			this.GridWidtTextBox.Location = new System.Drawing.Point(276, 30);
			this.GridWidtTextBox.Name = "GridWidtTextBox";
			this.GridWidtTextBox.Size = new System.Drawing.Size(84, 20);
			this.GridWidtTextBox.TabIndex = 3;
			// 
			// GridHeightTextBox
			// 
			this.GridHeightTextBox.Location = new System.Drawing.Point(375, 29);
			this.GridHeightTextBox.Name = "GridHeightTextBox";
			this.GridHeightTextBox.Size = new System.Drawing.Size(84, 20);
			this.GridHeightTextBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(273, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Grid Width:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(372, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "GridHeight:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(273, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "ID:";
			// 
			// IDTextBox
			// 
			this.IDTextBox.Location = new System.Drawing.Point(275, 69);
			this.IDTextBox.Name = "IDTextBox";
			this.IDTextBox.Size = new System.Drawing.Size(184, 20);
			this.IDTextBox.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(273, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Name:";
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(275, 108);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(184, 20);
			this.NameTextBox.TabIndex = 10;
			// 
			// TileEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 280);
			this.ControlBox = false;
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.IDTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GridHeightTextBox);
			this.Controls.Add(this.GridWidtTextBox);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Name = "TileEditorForm";
			this.ShowInTaskbar = false;
			this.Text = "Tile Editor";
			this.TopMost = true;
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GridWidtTextBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridHeightTextBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IDTextBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel TileEditorPanel;
		private System.Windows.Forms.Button DoneButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.NumericUpDown GridWidtTextBox;
		private System.Windows.Forms.NumericUpDown GridHeightTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown IDTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox NameTextBox;
	}
}