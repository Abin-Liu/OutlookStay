using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookStay
{
	partial class ButtonForm : Form
	{
		public Action OnButtonClick { get; set; }

		public ButtonForm()
		{
			InitializeComponent();
		}

		public void ApplyConfig(ConfigHandler config)
		{
			var size = new Size(config.ButtonWidth, config.ButtonHeight);
			MinimumSize = size;
			MaximumSize = size;
			Size = size;
		}

		public void ApplyLocation(Point location)
		{
			if (location == Point.Empty)
			{
				Hide();
			}
			else
			{
				Location = location;
				Show();
			}
		}

		private void ButtonForm_Load(object sender, EventArgs e)
		{
			toolTip1.SetToolTip(this, "Use \"File -> Exit\" to actually exit.");
		}

		private void ButtonForm_MouseEnter(object sender, EventArgs e)
		{
			BackColor = Color.Red;
		}

		private void ButtonForm_MouseLeave(object sender, EventArgs e)
		{
			BackColor = SystemColors.Menu;
		}

		private void ButtonForm_Click(object sender, EventArgs e)
		{
			OnButtonClick?.Invoke();
			Hide();
		}
	}
}
