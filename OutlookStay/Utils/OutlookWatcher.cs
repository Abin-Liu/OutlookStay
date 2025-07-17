using System;
using System.Drawing;
using Win32API;

namespace OutlookStay
{
	class OutlookWatcher
	{
		public ConfigHandler Config { get; set; }
		public Point Location => m_location;

		IntPtr m_outlook = IntPtr.Zero;
		Point m_location = Point.Empty;

		public bool Check()
		{
			var outlook = FindOutlook();
			var location = GetButtonLocation(outlook);
			if (location == m_location)
			{
				return false;
			}

			m_location = location;
			return true;
		}

		public void Minimize()
		{
			if (m_outlook == IntPtr.Zero)
			{
				return;
			}

			Window.ShowWindow(m_outlook, Window.SW_MINIMIZE);
			Clear();
		}

		public void Clear()
		{
			m_outlook = IntPtr.Zero;
			m_location = Point.Empty;
		}

		IntPtr FindOutlook()
		{
			if (m_outlook != IntPtr.Zero && Window.IsWindow(m_outlook))
			{
				return m_outlook;
			}

			var outlook = Window.FindWindow("rctrl_renwnd32", null);
			if (!IsActiveWindow(outlook))
			{
				outlook = IntPtr.Zero;
			}

			m_outlook = outlook;
			return outlook;
		}

		bool IsActiveWindow(IntPtr handle)
		{
			if (handle == IntPtr.Zero)
			{
				return false;
			}

			if (!Window.IsWindowVisible(handle) || Window.IsMinimized(handle))
			{
				return false;
			}

			if (handle != Window.GetForegroundWindow())
			{
				return false;
			}

			return true;
		}

		Point GetButtonLocation(IntPtr outlook)
		{
			if (outlook == IntPtr.Zero)
			{
				return Point.Empty;
			}

			// 目前版本的outlook使用GetWindowRect无法正确获得宽度
			//var windowRect = Window.GetWindowRect(outlook);
			var clientRect = Window.GetClientRect(outlook);

			var location = new Point(clientRect.Width - Config.ButtonWidth);
			location.Offset(Config.XOffset, Config.YOffset);

			var w2s = Window.WindowToScreen(m_outlook);
			location.Offset(w2s);
			return location;
		}
	}
}
