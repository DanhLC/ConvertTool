using System;
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

				if (currentTimestamp < 1) return string.Empty;

				return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(currentTimestamp).ToString("dd/MM/yyyy");
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
				var currentDateTime = ToDateTimenullWithFormat(datetime);

				if (currentDateTime == null) return string.Empty;

				var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				var timeSpan = (currentDateTime ?? DateTime.Now).ToUniversalTime() - unixEpoch;
				var timestamp = (long)timeSpan.TotalMilliseconds;
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
	}
}
