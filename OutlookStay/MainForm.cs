using System;
using System.Drawing;
using System.Windows.Forms;
using UIToolkits;
using AbinLibs;

namespace OutlookStay
{
	public partial class MainForm : Form
	{
		OutlookWatcher m_outlook = new OutlookWatcher();
		bool m_autoStartup = false;		
		bool m_busy = false;
		Rectangle m_rect = Rectangle.Empty;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{			
			Visible = false;
			ShowInTaskbar = false;
			toolTip1.SetToolTip(this, "Use \"File -> Exit\" to actually exit.");

			if (Constants.DevTest)
			{
				BackColor = Color.Green;
			}

			try
			{
				m_autoStartup = RegistryHelper.CheckAutoStartApp(ProductName) != null;
				menuAutoStartup.Checked = m_autoStartup;
			}
			catch (Exception)
			{
			}			

			BeginInvoke(new Action(() => {
				Hide();
				timer1.Enabled = true;
			}));			
		}

		void UpdateBoundary(Rectangle rect, IntPtr outlook)
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
				UpdateBoundary(rect, m_outlook.Outlook);
			}
			catch (Exception)
			{
			}
			finally
			{
				m_busy = false;
			}
		}

		private void MenuAutoStartup_Click(object sender, EventArgs e)
		{
			var autoStartup = !m_autoStartup;

			try
			{
				if (autoStartup)
				{
					RegistryHelper.AddAutoStartApp(ProductName, Application.ExecutablePath);
				}
				else
				{
					RegistryHelper.RemoveAutoStartApp(ProductName);
				}

				m_autoStartup = autoStartup;
				menuAutoStartup.Checked = autoStartup;
			}
			catch (Exception ex)
			{
				Messagex.Error(ex.Message);
			}
		}

		private void MenuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MainForm_Click(object sender, EventArgs e)
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

		private void MainForm_MouseEnter(object sender, EventArgs e)
		{
			BackColor = Color.Red;
		}

		private void MainForm_MouseLeave(object sender, EventArgs e)
		{
			if (Constants.DevTest)
			{
				BackColor = Color.Green;
			}
			else
			{
				BackColor = SystemColors.Menu;
			}
		}
	}
}
