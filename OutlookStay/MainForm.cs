using System;
using System.Windows.Forms;

namespace OutlookStay
{
	public partial class MainForm : Form
	{
		ConfigHandler m_config = new ConfigHandler();
		OutlookWatcher m_outlook = new OutlookWatcher();
		ButtonForm m_button = new ButtonForm();
		bool m_configShow = false;

		public MainForm()
		{
			InitializeComponent();
			m_button.OnButtonClick = m_outlook.Minimize;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			m_config.Load();
			m_outlook.Config = m_config;
			m_button.ApplyConfig(m_config);
			timer1.Interval = m_config.Interval;
			timer1.Enabled = true;

			Visible = false;
			ShowInTaskbar = false;

			BeginInvoke(new Action(() => {
				Hide();
			}));
		}

		void DoConfig()
		{
			if (m_configShow)
			{
				return;
			}

			m_configShow = true;

			ConfigForm dlg = new ConfigForm();
			dlg.Config = m_config;
			var result = dlg.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				m_config.Save();
				m_button.ApplyConfig(m_config);
				timer1.Interval = m_config.Interval;
			}

			m_configShow = false;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (m_outlook.Check())
			{
				m_button.ApplyLocation(m_outlook.Location);
			}	
		}

		private void MenuSettings_Click(object sender, EventArgs e)
		{
			DoConfig();
		}

		private void MenuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			DoConfig();
		}
	}
}
