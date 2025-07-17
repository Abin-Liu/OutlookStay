namespace OutlookStay
{
	partial class ConfigForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOutlookClass = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtButtonWidth = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtButtonHeight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtXOffset = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtYOffset = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.numInterval = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.chkAutoRun = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(86, 248);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(185, 248);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Outlook class:";
			// 
			// txtOutlookClass
			// 
			this.txtOutlookClass.Location = new System.Drawing.Point(123, 20);
			this.txtOutlookClass.Name = "txtOutlookClass";
			this.txtOutlookClass.Size = new System.Drawing.Size(193, 20);
			this.txtOutlookClass.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Button width:";
			// 
			// txtButtonWidth
			// 
			this.txtButtonWidth.Location = new System.Drawing.Point(123, 52);
			this.txtButtonWidth.Name = "txtButtonWidth";
			this.txtButtonWidth.Size = new System.Drawing.Size(193, 20);
			this.txtButtonWidth.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Button height:";
			// 
			// txtButtonHeight
			// 
			this.txtButtonHeight.Location = new System.Drawing.Point(123, 84);
			this.txtButtonHeight.Name = "txtButtonHeight";
			this.txtButtonHeight.Size = new System.Drawing.Size(193, 20);
			this.txtButtonHeight.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "X offset:";
			// 
			// txtXOffset
			// 
			this.txtXOffset.Location = new System.Drawing.Point(123, 116);
			this.txtXOffset.Name = "txtXOffset";
			this.txtXOffset.Size = new System.Drawing.Size(193, 20);
			this.txtXOffset.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Y offset";
			// 
			// txtYOffset
			// 
			this.txtYOffset.Location = new System.Drawing.Point(123, 148);
			this.txtYOffset.Name = "txtYOffset";
			this.txtYOffset.Size = new System.Drawing.Size(193, 20);
			this.txtYOffset.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Sampling interval:";
			// 
			// numInterval
			// 
			this.numInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numInterval.Location = new System.Drawing.Point(123, 180);
			this.numInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numInterval.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.numInterval.Name = "numInterval";
			this.numInterval.Size = new System.Drawing.Size(90, 20);
			this.numInterval.TabIndex = 11;
			this.numInterval.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(219, 182);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "milliseconds";
			// 
			// chkAutoRun
			// 
			this.chkAutoRun.AutoSize = true;
			this.chkAutoRun.Location = new System.Drawing.Point(27, 215);
			this.chkAutoRun.Name = "chkAutoRun";
			this.chkAutoRun.Size = new System.Drawing.Size(151, 17);
			this.chkAutoRun.TabIndex = 15;
			this.chkAutoRun.Text = "Auto-run on system startup";
			this.chkAutoRun.UseVisualStyleBackColor = true;
			// 
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 297);
			this.Controls.Add(this.chkAutoRun);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.numInterval);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtYOffset);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtXOffset);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtButtonHeight);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtButtonWidth);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtOutlookClass);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.ConfigForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOutlookClass;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtButtonWidth;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtButtonHeight;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtXOffset;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtYOffset;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numInterval;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkAutoRun;
	}
}