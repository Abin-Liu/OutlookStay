using System;
using System.Drawing;
using AbinLibs;

namespace OutlookStay
{
	internal class Constants
	{
		public static readonly string OutlookClass = AppConfig.ReadAppSettings("OutlookClass");
		public static readonly Size NormalSize = ReadSize("NormalSize");
		public static readonly Size MaximzedSize = ReadSize("MaximzedSize");
		public static readonly Point ButtonOffset = ReadPoint("Offset");

		static int ConvertInt(object value)
		{
			try
			{
				return Convert.ToInt32(value);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		static int[] ReadInts(string key)
		{
			var values = AppConfig.ReadAppSettings(key, ',', ConvertInt);
			if (values.Length == 0)
			{
				return new int[] { 0, 0 };
			}

			if (values.Length == 1)
			{
				return new int[] { values[0], values[0] };
			}

			return values;			
		}

		static Size ReadSize(string key)
		{
			var values = ReadInts(key);
			return new Size(values[0], values[1]);
		}

		static Point ReadPoint(string key)
		{
			var values = ReadInts(key);
			return new Point(values[0], values[1]);
		}
	}
}
