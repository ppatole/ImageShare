using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    public class ConversionHelper
    {
        public static int ConvertToInt(string value)
        {
            int returnValue = 0;
            int.TryParse(value, out returnValue);
            return returnValue;
        }

        public static int? ConvertToIntNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            int returnValue = 0;
            int.TryParse(value, out returnValue);
            return returnValue;
        }

        public static decimal ConvertToDecimal(string value)
        {
            decimal returnValue = 0;
            decimal.TryParse(value, out returnValue);
            return returnValue;
        }

        public static decimal? ConvertToDecimalNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            decimal returnValue = 0;
            decimal.TryParse(value, out returnValue);
            return returnValue;
        }

        public static bool ConvertToBool(string value)
        {
            bool returnValue = false;
            bool.TryParse(value, out returnValue);
            return returnValue;
        }

        public static bool? ConvertToBoolNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            bool returnValue = false;
            bool.TryParse(value, out returnValue);
            return returnValue;
        }

        public static long ConvertToLong(string value)
        {
            long returnValue = 0;
            long.TryParse(value, out returnValue);
            return returnValue;
        }

        public static long? ConvertToLongNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            long returnValue = 0;
            long.TryParse(value, out returnValue);
            return returnValue;
        }

        public static DateTime ConvertToDate(string value)
        {
            DateTime returnValue = new DateTime();
            DateTime.TryParse(value, out returnValue);
            return returnValue;
        }

        public static DateTime? ConvertToDateNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            DateTime returnValue = new DateTime();
            DateTime.TryParse(value, out returnValue);
            return returnValue;
        }
    }
}
