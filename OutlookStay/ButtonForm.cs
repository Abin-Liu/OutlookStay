using System;
using System.Drawing;
using System.Windows.Forms;

namespace OutlookStay
{
	public partial class ButtonForm : Form
	{
		OutlookWatcher m_outlook = new OutlookWatcher();
		bool m_busy = false;
		Rectangle m_rect = Rectangle.Empty;

		public ButtonForm()
		{
			InitializeComponent();
			toolTip1.SetToolTip(this, "Use \"File -> Exit\" to actually exit.");
		}

		public void StartWatcher()
		{
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
				m_outlook.Activate();
			}));
		}

		private void ButtonForm_Load(object sender, EventArgs e)
		{
			
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
				var rect = m_outlook.GetButtonRect();
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

		private void ButtonForm_Click(object sender, EventArgs e)
		{
			MouseEventArgs args = (MouseEventArgs)e;
			if (args.Button != MouseButtons.Left)
			{
				return;
			}

			m_outlook.Minimize();
			m_rect = Rectangle.Empty;
			Hide();
		}

		private void ButtonForm_MouseEnter(object sender, EventArgs e)
		{
			BackColor = Color.Red;
		}

		private void ButtonForm_MouseLeave(object sender, EventArgs e)
		{
			BackColor = SystemColors.Menu;
		}
	}
}
