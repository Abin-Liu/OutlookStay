using System;
using System.Threading;
using System.Windows.Forms;

namespace OutlookStay
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			bool success;
			_ = new Mutex(true, "{2AAA06D3-AB03-4219-9A3B-B4A55E15B429}", out success);
			if (!success)
			{
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
