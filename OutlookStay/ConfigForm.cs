using System;
using System.Windows.Forms;
using UIToolkits;

namespace OutlookStay
{
	partial class ConfigForm : Form
	{
		public ConfigHandler Config { get; set; }

		public ConfigForm()
		{
			InitializeComponent();
		}

		private void ConfigForm_Load(object sender, EventArgs e)
		{
			txtOutlookClass.Text = Config.OutlookClass;
			txtButtonWidth.Text = Config.ButtonWidth.ToString();
			txtButtonHeight.Text = Config.ButtonHeight.ToString();
			txtXOffset.Text = Config.XOffset.ToString();
			txtYOffset.Text = Config.YOffset.ToString();
			numInterval.Value = Config.Interval;
			chkAutoRun.Checked = Config.AutoRun;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				var outlookClass = txtOutlookClass.Text?.Trim();
				if (string.IsNullOrEmpty(outlookClass))
				{
					throw new Exception("Outlook class is required.");
				}

				var buttonWidth = Convert.ToInt32(txtButtonWidth.Text?.Trim());
				var buttonHeight = Convert.ToInt32(txtButtonHeight.Text?.Trim());
				var xOffset = Convert.ToInt32(txtXOffset.Text?.Trim());
				var yOffset = Convert.ToInt32(txtYOffset.Text?.Trim());
				var interval = (int)numInterval.Value;
				interval = ConfigHandler.ValidateInterval(interval);

				Config.OutlookClass = outlookClass;
				Config.ButtonWidth = buttonWidth;
				Config.ButtonHeight = buttonHeight;
				Config.XOffset = xOffset;
				Config.YOffset = yOffset;
				Config.Interval = interval;
				Config.AutoRun = chkAutoRun.Checked;

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Messagex.Warning(this, ex.Message);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
