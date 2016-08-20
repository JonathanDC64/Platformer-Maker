using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tileset_Creator
{
	public partial class TileInfoControl : UserControl
	{
		private TilesetCreatorForm TCForm;
		public TileInfoControl(TilesetCreatorForm form)
		{
			InitializeComponent();
			TCForm = form;
		}
	}
}
