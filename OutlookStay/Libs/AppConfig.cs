using System;
using System.Configuration;
using System.Linq;

namespace AbinLibs
{
	/// <summary>
	/// 配置文件读取类
	/// </summary>
	public class AppConfig
	{
		#region ConnectionStrings
		/// <summary>
		/// 读取*.config中ConnectionStrings段的值
		/// </summary>
		/// <param name="key">配置名</param>
		/// <returns>连接字符串，不存在则抛出异常</returns>
		public static string ReadConnectionString(string key)
		{
			return ConfigurationManager.ConnectionStrings[key].ConnectionString;
		}
		#endregion

		#region AppSettings
		/// <summary>
		/// 读取*.config中AppSettings段的值，阻止exception
		/// </summary>
		/// <param name="key">配置名</param>
		/// <param name="defaultVal">默认值</param>
		/// <returns>返回配置值，不存在则返回默认值</returns>
		public static string ReadAppSettings(string key, string defaultVal = null)
		{
			try
			{
				return ConfigurationManager.AppSettings[key];
			}
			catch
			{
				return defaultVal;
			}
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为int类型
		/// </summary>
		/// <param name="key">配置名</param>
		/// <param name="defaultVal">默认值</param>
		/// <returns>返回配置值，不存在则返回默认值</returns>
		public static int ReadAppSettings(string key, int defaultVal)
		{
			string value = ReadAppSettings(key);
			if (string.IsNullOrEmpty(value))
			{
				return defaultVal;
			}

			try
			{
				return Convert.ToInt32(value);
			}
			catch
			{
				return defaultVal;
			}
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为double类型
		/// </summary>
		/// <param name="key">配置名</param>
		/// <param name="defaultVal">默认值</param>
		/// <returns>返回配置值，不存在则返回默认值</returns>
		public static double ReadAppSettings(string key, double defaultVal)
		{
			string value = ReadAppSettings(key);
			if (string.IsNullOrEmpty(value))
			{
				return defaultVal;
			}

			try
			{
				return Convert.ToDouble(value);
			}
			catch
			{
				return defaultVal;
			}
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为decimal类型
		/// </summary>
		/// <param name="key">配置名</param>
		/// <param name="defaultVal">默认值</param>
		/// <returns>返回配置值，不存在则返回默认值</returns>
		public static decimal ReadAppSettings(string key, decimal defaultVal)
		{
			string value = ReadAppSettings(key);
			if (string.IsNullOrEmpty(value))
			{
				return defaultVal;
			}

			try
			{
				return Convert.ToDecimal(value);
			}
			catch
			{
				return defaultVal;
			}
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为bool类型
		/// </summary>
		/// <param name="key">配置名</param>
		/// <param name="defaultVal">默认值</param>
		/// <returns>返回配置值，不存在则返回默认值</returns>
		public static bool ReadAppSettings(string key, bool defaultVal)
		{
			string value = ReadAppSettings(key);
			if (string.IsNullOrEmpty(value))
			{
				return defaultVal;
			}

			if (string.IsNullOrEmpty(value))
			{
				return defaultVal;
			}

			if (value == "1")
			{
				return true;
			}

			if (value == "0")
			{
				return false;
			}

			try
			{
				return Convert.ToBoolean(value);
			}
			catch
			{
				return defaultVal;
			}
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为DateTime类型
		/// </summary>
		/// <param name="key">配置名</param>
		/// <param name="defaultVal">默认值</param>
		/// <returns>返回配置值，不存在则返回DateTime.MinValue</returns>
		public static DateTime ReadAppSettings(string key, DateTime defaultVal)
		{
			string value = ReadAppSettings(key);
			if (string.IsNullOrEmpty(value))
			{
				return defaultVal;
			}

			try
			{
				return Convert.ToDateTime(value);
			}
			catch
			{
				return defaultVal;
			}
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为字符串数组
		/// </summary>
		/// <param name="key">配置名</param>
		/// <param name="separator">分隔字符，例如','</param>
		/// <returns>字符串数组</returns>
		public static string[] ReadAppSettings(string key, char separator)
		{
			string value = ReadAppSettings(key) ?? string.Empty;
			var items = value.Split(separator).ToList().ConvertAll(x => x.Trim());
			items.RemoveAll(x => x.Length == 0);
			return items.ToArray();
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为自定义类型数组
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="key">配置名</param>
		/// <param name="separator">分隔字符，例如','</param>
		/// <param name="converter">类型转换函数</param>
		/// <returns>自定义类型数组</returns>
		public static T[] ReadAppSettings<T>(string key, char separator, Func<string, T> converter)
		{
			var items = ReadAppSettings(key, separator);
			T[] results = new T[items.Length];
			for (int i = 0; i <  results.Length; i++)
			{
				results[i] = converter(items[i]);
			}
			return results;
		}

		/// <summary>
		/// 读取*.config中AppSettings段的值并转化为自定义类型数组
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="key">配置名</param>
		/// <param name="separator">分隔字符，例如','</param>
		/// <param name="converter">类型转换函数</param>
		/// <returns>自定义类型数组</returns>
		public static T[] ReadAppSettings<T>(string key, char separator, Func<object, T> converter)
		{
			var items = ReadAppSettings(key, separator);
			T[] results = new T[items.Length];
			for (int i = 0; i < results.Length; i++)
			{
				results[i] = converter(items[i]);
			}
			return results;
		}

		#endregion
	}
}