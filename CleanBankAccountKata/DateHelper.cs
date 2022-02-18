using System;
using System.Globalization;

namespace CleanBankAccountKata
{
    internal class DateHelper
    {
        public const string DEFAULT_DATE_STRING_FORMAT = "dd/MM/yyyy";
        public static DateTime Get(string dateString)
        {
            return DateTime.ParseExact(dateString, DEFAULT_DATE_STRING_FORMAT, CultureInfo.InvariantCulture);
        }
    }
}