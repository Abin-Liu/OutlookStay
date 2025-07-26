using System;
using System.Drawing;
using System.Windows.Forms;

namespace OutlookStay
{
	public partial class ButtonForm : Form
	{
		bool m_busy = false;
		Rectangle m_rect = Rectangle.Empty;

		public ButtonForm()
		{
			InitializeComponent();
			toolTip1.SetToolTip(this, "Use \"File -> Exit\" to actually exit.");
			timer1.Enabled = true;
		}		

		void UpdateBoundary(Rectangle rect)
		{
			if (rect.IsEmpty)
			{
				Hide();
				return;
			}

			Location = rect.Location;
			Size = rect.Size;
			Show();

			BeginInvoke(new Action(() => {
				Outlook.SetForeground();
			}));
		}		

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (m_busy)
			{
				return;
			}

			m_busy = true;
			try
			{
				var rect = Outlook.GetCloseButtonRect();
				if (rect == m_rect)
				{
					return;
				}

				m_rect = rect;
				UpdateBoundary(rect);
			}
			catch (Exception)
			{
			}
			finally
			{
				m_busy = false;
			}
		}		

		private void ButtonForm_MouseEnter(object sender, EventArgs e)
		{
			BackColor = Color.Red;
		}

		private void ButtonForm_MouseLeave(object sender, EventArgs e)
		{
			BackColor = SystemColors.Menu;
		}

		private void ButtonForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}

			Outlook.Minimize();
			m_rect = Rectangle.Empty;
			Hide();
		}
	}
}
