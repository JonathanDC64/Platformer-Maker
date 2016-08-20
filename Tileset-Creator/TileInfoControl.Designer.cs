namespace Tileset_Creator
{
	partial class TileInfoControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NameLabel = new System.Windows.Forms.Label();
			this.IDLabel = new System.Windows.Forms.Label();
			this.EditButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(11, 10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(80, 80);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(97, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "ID:";
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(133, 10);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(61, 13);
			this.NameLabel.TabIndex = 3;
			this.NameLabel.Text = "NameLabel";
			// 
			// IDLabel
			// 
			this.IDLabel.AutoSize = true;
			this.IDLabel.Location = new System.Drawing.Point(133, 23);
			this.IDLabel.Name = "IDLabel";
			this.IDLabel.Size = new System.Drawing.Size(44, 13);
			this.IDLabel.TabIndex = 4;
			this.IDLabel.Text = "IDLabel";
			// 
			// EditButton
			// 
			this.EditButton.Location = new System.Drawing.Point(100, 67);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(103, 23);
			this.EditButton.TabIndex = 5;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = true;
			// 
			// TileInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.IDLabel);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Name = "TileInfoControl";
			this.Size = new System.Drawing.Size(207, 100);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label IDLabel;
		private System.Windows.Forms.Button EditButton;
	}
}
