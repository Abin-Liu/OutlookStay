using System;
using System.Drawing;
using Win32API;

namespace OutlookStay
{
	class OutlookWatcher
	{
		public IntPtr Outlook => m_outlook;
		IntPtr m_outlook = IntPtr.Zero;

		public Rectangle GetButtonRect()
		{
			var outlook = FindOutlook();
			return GetButtonRect(outlook);
		}	
		
		public void Activate()
		{
			if (m_outlook == IntPtr.Zero)
			{
				return;
			}

			Window.SetForegroundWindow(m_outlook);
		}

		public void Minimize()
		{
			if (m_outlook == IntPtr.Zero)
			{
				return;
			}

			Window.ShowWindow(m_outlook, Window.SW_MINIMIZE);
			m_outlook = IntPtr.Zero;
		}		

		IntPtr FindOutlook()
		{
			if (m_outlook != IntPtr.Zero && Window.IsWindow(m_outlook))
			{
				return m_outlook;
			}

			var outlook = Window.FindWindow(Constants.OutlookClass, null);
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

			if (!Constants.DevTest && handle != Window.GetForegroundWindow())
			{
				return false;
			}

			return true;
		}

		Rectangle GetButtonRect(IntPtr outlook)
		{
			if (outlook == IntPtr.Zero)
			{
				return Rectangle.Empty;
			}

			// 目前版本的outlook使用GetWindowRect无法正确获得宽度
			//var windowRect = Window.GetWindowRect(outlook);
			var clientRect = Window.GetClientRect(outlook);

			var buttonSize = Window.IsMaximized(outlook) ? Constants.MaximzedButtonSize : Constants.NormalButtonSize;

			var location = new Point(clientRect.Width - buttonSize.Width, 0);
			location.Offset(Constants.ButtonOffset);

			var screenOffset = Window.WindowToScreen(m_outlook);
			location.Offset(screenOffset);
			return new Rectangle(location, buttonSize);
		}
	}
}
