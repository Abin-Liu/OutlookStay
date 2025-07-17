using AbinLibs;
using System;
using System.Windows.Forms;

namespace OutlookStay
{
	class ConfigHandler
	{
		const string ProductName = "OutlookStay";
		const int MinInterval = 200;
		const int MaxInterval = 1000;

		public string OutlookClass { get; set; }
		public int ButtonWidth { get; set; }
		public int ButtonHeight { get; set; }
		public int XOffset { get; set; }
		public int YOffset { get; set; }
		public int Interval { get; set; }
		public bool AutoRun { get; set; }

		public void Load()
		{
			var reg = new RegistryHelper();
			reg.Open("Abin", ProductName);
			try
			{
				OutlookClass = reg.ReadString("OutlookClass", "rctrl_renwnd32");
				ButtonWidth = reg.ReadInt("ButtonWidth", 48);
				ButtonHeight = reg.ReadInt("ButtonHeight", 48);
				XOffset = reg.ReadInt("XOffset", 8);
				YOffset = reg.ReadInt("YOffset", 1);
				Interval = reg.ReadInt("Interval", 200);
				Interval = ValidateInterval(Interval);
			}
			catch
			{
			}
			finally
			{
				reg.Close();
			}

			AutoRun = RegistryHelper.CheckAutoStartApp(ProductName) != null;
		}

		public void Save()
		{
			var reg = new RegistryHelper();
			reg.Open("Abin", ProductName, true);
			try
			{
				reg.WriteString("OutlookClass", OutlookClass);
				reg.WriteInt("ButtonWidth", ButtonWidth);
				reg.WriteInt("ButtonHeight", ButtonHeight);
				reg.WriteInt("XOffset", XOffset);
				reg.WriteInt("XOffset", XOffset);
				reg.WriteInt("Interval", Interval);
			}
			catch
			{
			}
			finally
			{
				reg.Close();
			}

			if (AutoRun)
			{
				RegistryHelper.AddAutoStartApp(ProductName, Application.ExecutablePath);
			}
			else
			{
				RegistryHelper.RemoveAutoStartApp(ProductName);
			}
		}

		public static int ValidateInterval(int interval)
		{
			interval = Math.Max(interval, MinInterval);
			interval = Math.Min(interval, MaxInterval);
			return interval;
		}
	}
}
