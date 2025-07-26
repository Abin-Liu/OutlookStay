using System;
using System.Drawing;
using Win32API;

namespace OutlookStay
{
	static class Outlook
	{
		public static IntPtr FindWindow()
		{
			return Window.FindWindow(Constants.OutlookClass, null);
		}

		public static Rectangle GetCloseButtonRect()
		{
			var hwnd = FindWindow();
			if (hwnd == null || Window.GetForegroundWindow() != hwnd)
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

		public static void SetForeground()
		{
			var hwnd = FindWindow();
			if (hwnd != IntPtr.Zero)
			{
				Window.SetForegroundWindow(hwnd);
			}			
		}

		public static void Minimize()
		{
			var hwnd = FindWindow();
			if (hwnd != IntPtr.Zero)
			{
				Window.ShowWindow(hwnd, Window.SW_MINIMIZE);
			}			
		}		
	}
}
