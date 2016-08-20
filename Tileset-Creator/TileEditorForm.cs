using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tileset_Creator
{
	public partial class TileEditorForm : Form
	{
		public TileEditorForm()
		{
			InitializeComponent();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void DoneButton_Click(object sender, EventArgs e)
		{

		}
	}
}
