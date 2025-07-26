namespace OutlookStay
{
	partial class ButtonForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// toolTip1
			// 
			this.toolTip1.ToolTipTitle = "Hide Outlook";
			// 
			// timer1
			// 
			this.timer1.Interval = 300;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ButtonForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Menu;
			this.ClientSize = new System.Drawing.Size(100, 100);
			this.ControlBox = false;
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(100, 100);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(16, 16);
			this.Name = "ButtonForm";
			this.Opacity = 0.2D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ButtonForm";
			this.TopMost = true;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonForm_MouseDown);
			this.MouseEnter += new System.EventHandler(this.ButtonForm_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.ButtonForm_MouseLeave);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Timer timer1;
	}
}