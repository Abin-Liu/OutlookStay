using System;
using System.Drawing;
using Win32API;

namespace OutlookStay
{
	class OutlookWatcher
	{
		IntPtr m_hwnd = IntPtr.Zero;

		public Rectangle GetButtonRect()
		{
			var hwnd = FindOutlook();
			m_hwnd = hwnd;

			if (hwnd == IntPtr.Zero)
			{
				return Rectangle.Empty;
			}

			// 目前版本的outlook使用GetWindowRect无法正确获得宽度
			//var windowRect = Window.GetWindowRect(outlook);
			var clientRect = Window.GetClientRect(hwnd);

			var buttonSize = Window.IsMaximized(hwnd) ? Constants.MaximzedSize : Constants.NormalSize;

			var location = new Point(clientRect.Width - buttonSize.Width, 0);
			location.Offset(Constants.ButtonOffset);

			var screenOffset = Window.WindowToScreen(hwnd);
			location.Offset(screenOffset);
			return new Rectangle(location, buttonSize);
		}

		public void Activate()
		{
			if (m_hwnd == IntPtr.Zero)
			{
				return;
			}

			Window.SetForegroundWindow(m_hwnd);
		}

		public void Minimize()
		{
			if (m_hwnd == IntPtr.Zero)
			{
				return;
			}

			Window.ShowWindow(m_hwnd, Window.SW_MINIMIZE);
			m_hwnd = IntPtr.Zero;
		}

		IntPtr FindOutlook()
		{
			var hwnd = Window.FindWindow(Constants.OutlookClass, null);
			if (!IsActiveWindow(hwnd))
			{
				hwnd = IntPtr.Zero;
			}
			return hwnd;
		}

		static bool IsActiveWindow(IntPtr hwnd)
		{
			if (hwnd == IntPtr.Zero)
			{
				return false;
			}			

			//if (Window.IsMinimized(hwnd))
			//{
			//	return false;
			//}

			if (hwnd != Window.GetForegroundWindow())
			{
				return false;
			}

			return true;
		}
	}
}
