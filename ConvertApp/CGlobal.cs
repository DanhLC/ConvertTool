using System;
using System.Configuration;
using System.Globalization;
using System.Numerics;

namespace ConvertApp
{
	public class CGlobal
	{
		/// <summary>
		/// Convert to long
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static long ToLong(object obj)
		{
			try
			{
				if (obj == null || obj.ToString().Length == 0) return 0;

				return Convert.ToInt64(obj);
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// Biginteger to hex
		/// </summary>
		/// <param name="strBigInteger">Big integer string</param>
		public static string BigIntegerToHex(string strBigInteger)
		{
			try
			{
				BigInteger bigIntegerConvert = 0;
				bigIntegerConvert = BigInteger.Parse(strBigInteger);

				return bigIntegerConvert.ToString("X");
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Hex to biginteger
		/// </summary>
		/// <param name="strHex">Hex string</param>
		public static string HexToBigInteger(string strHex)
		{
			try
			{
				return BigInteger.Parse(strHex, System.Globalization.NumberStyles.HexNumber).ToString();
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Timestamp to datetime
		/// </summary>
		/// <param name="timeStamp"></param>
		/// <returns></returns>
		public static string TimestampToDateTime(object timeStamp)
		{
			try
			{
				var currentTimestamp = ToLong(timeStamp);
				var format = ValidDateFormat(ConfigurationManager.AppSettings["FormatDateTime"]);

				if (currentTimestamp < 1) return string.Empty;

				return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
					.AddMilliseconds(currentTimestamp)
					.ToLocalTime()
					.ToString(format);
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// DateTime to timestamp
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public static string DateTimeToTimestamp(object datetime)
		{
			try
			{
				var format = ValidDateFormat(ConfigurationManager.AppSettings["FormatDateTime"]);
				var currentDateTime = ToDateTimenullWithFormat(datetime, format);

				if (currentDateTime == null) return string.Empty;

				var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				var timeSpan = (currentDateTime.Value.ToUniversalTime() - unixEpoch);
				var timestamp = ToLong(timeSpan.TotalMilliseconds);
				return timestamp.ToString();
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// To datetime null with format
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static DateTime? ToDateTimenullWithFormat(object obj, string format = "dd/MM/yyyy")
		{
			try
			{
				if (obj == null || obj.ToString().Length == 0) return null;

				return DateTime.ParseExact(obj.ToString(), format, System.Globalization.CultureInfo.InvariantCulture);
			}
			catch
			{
				return (DateTime?)null;
			}
		}

		/// <summary>
		/// Is empty string
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsEmptyString(string obj)
		{
			try
			{
				return string.IsNullOrEmpty(obj) || string.IsNullOrWhiteSpace(obj);
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Valid date format
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string ValidDateFormat(string format)
		{
			try
			{
				var dateTimeTest = DateTime.Now;
				DateTime result;

				if (IsValidDateTimeFormat(format, out result))
				{
					return format;
				}
				else
				{
					return "dd/MM/yyyy";
				}
			}
			catch
			{
				return "dd/MM/yyyy";
			}
		}

		/// <summary>
		/// Is valid datetime format
		/// </summary>
		/// <param name="format"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool IsValidDateTimeFormat(string format, out DateTime result)
		{
			result = DateTime.MinValue;

			try
			{
				var dateTimeTest = new DateTime(2000, 1, 1); 
				return DateTime.TryParseExact(dateTimeTest.ToString(format), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			}
			catch
			{
				return false;
			}
		}
	}
}
