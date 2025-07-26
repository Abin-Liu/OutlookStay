using System;
using System.Windows.Forms;
using UIToolkits;
using AbinLibs;

namespace OutlookStay
{
	public partial class MainForm : Form
	{			
		ButtonForm m_button = new ButtonForm();
		bool m_autoStartup = false;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				m_autoStartup = RegistryHelper.CheckAutoStartApp(ProductName) != null;
				menuAutoStartup.Checked = m_autoStartup;
			}
			catch (Exception)
			{
			}

			Visible = false;
			ShowInTaskbar = false;
			m_button.StartWatcher();

			BeginInvoke(new Action(() => {
				Hide();				
			}));			
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
	}
}
