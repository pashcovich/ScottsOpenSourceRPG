using System;
using System.Globalization;
using System.Linq;

namespace DotNetToolBox
{
    public static class ExtensionMethods
    {
        #region Numeric methods

        public static bool IsNumeric(this string obj)
        {
            return obj.IsNumeric(CultureInfo.InvariantCulture);
        }

        public static bool IsNumericDatatype(this object obj)
        {
            switch(Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsNumeric(this string obj, CultureInfo cultureInfo)
        {
            if(obj == "NaN")
            {
                return false;
            }

            try
            {
                double x = double.Parse(obj, cultureInfo);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsApproximatelyEqualTo(this double initialValue, double value)
        {
            // Handle comparisons of floating point values that may not be exactly the same
            return (Math.Abs(initialValue - value) < 0.00001);
        }

        public static bool IsBetween(this double value, double lowerLimit, double upperLimit)
        {
            return ((value > lowerLimit) && (value < upperLimit));
        }

        public static bool IsBetweenOrEqualTo(this double value, double lowerLimit, double upperLimit)
        {
            return ((value >= lowerLimit) && (value <= upperLimit));
        }

        public static int WithLimitsOf(this int obj, int minimumValue, int maximumValue)
        {
            return obj.WithLowerLimitOf(minimumValue).WithUpperLimitOf(maximumValue);
        }

        public static int WithLowerLimitOf(this int obj, int minimumValue)
        {
            return Math.Max(obj, minimumValue);
        }

        public static int WithUpperLimitOf(this int obj, int maximumValue)
        {
            return Math.Min(obj, maximumValue);
        }

        public static bool IsNotEqualTo<T>(this T obj, T comparisonObject)
        {
            return !obj.Equals(comparisonObject);
        }

        #endregion

        #region String methods

        public static bool IsNotNullOrEmpty(this string obj)
        {
            return !string.IsNullOrWhiteSpace(obj);
        }

        public static bool IsAlphaNumeric(this string obj)
        {
            return obj.All(Char.IsLetterOrDigit);
        }

        public static bool ContainsAnUpperCaseCharacter(this string obj)
        {
            return obj.ContainsUpperCaseCharacters(1);
        }

        public static bool ContainsUpperCaseCharacters(this string obj, int minimumNumberofUpperCaseCharacters)
        {
            return obj.Count(char.IsUpper) >= minimumNumberofUpperCaseCharacters;
        }

        public static bool ContainsALowerCaseCharacter(this string obj)
        {
            return obj.ContainsUpperCaseCharacters(1);
        }

        public static bool ContainsLowerCaseCharacters(this string obj, int minimumNumberofLowerCaseCharacters)
        {
            return obj.Count(char.IsLower) >= minimumNumberofLowerCaseCharacters;
        }

        public static bool ContainsANumericCharacter(this string obj)
        {
            return obj.ContainsNumericCharacters(1);
        }

        public static bool ContainsNumericCharacters(this string obj, int minimumNumberofNumericCharacters)
        {
            return obj.Count(char.IsDigit) >= minimumNumberofNumericCharacters;
        }

        private static bool ContainsOnly(this string obj, string validCharacters)
        {
            return !obj.Where((t, i) => validCharacters.IndexOf(obj.Substring(i, 1), StringComparison.Ordinal) < 0).Any();
        }

        #endregion

        #region DateTime methods

        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return date.StartOfMonth().AddMonths(1).AddSeconds(-1);
        }

        #endregion
    }
}