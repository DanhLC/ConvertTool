using System;

namespace ConvertApp
{
	public interface IService
	{
		long ToLong(object obj);
		string BigIntegerToHex(string strBigInteger);
		string HexToBigInteger(string strHex);

		string TimestampToDateTime(object timeStamp);
		string DateTimeToTimestamp(object datetime);
		DateTime? ToDateTimenullWithFormat(object obj, string format = "dd/MM/yyyy");
		bool IsEmptyString(string obj);
		string ValidDateFormat(string format);
		bool IsValidDateTimeFormat(string format, out DateTime result);
	}
}
