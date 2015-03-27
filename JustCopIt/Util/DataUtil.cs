using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCopIt.Util
{
    class DataUtil
    {
        #region String

        public static bool IsAllEmpty(params string[] texts)
        {
            if (texts == null || texts.Length == 0) return true;
            return texts.All(IsNullOrEmptyOrWhiteSpace);
        }

        public static bool IsNullOrEmptyOrWhiteSpace(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        
        public static string Left(string inputString, int length)
        {
            return inputString.Substring(0, length);
        }

        public static string Right(string inputString, int length)
        {
            return inputString.Substring(inputString.Length - length, length);
        }

        public static string Mid(string inputString, int startIndex, int length)
        {
            return inputString.Substring(startIndex, length);
        }

        public static string Mid(string inputString, int startIndex)
        {
            return inputString.Substring(startIndex);
        }

        #endregion
        #region ConvertForNullData

        public static string StringForNull(object x)
        {
            try
            {
                if (x is DBNull)
                {
                    return "";
                }
                if (x == null)
                {
                    return "";
                }
                return x.ToString().Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static int IntegerForNull(object x)
        {
            try
            {
                if (x == null)
                {
                    return 0;
                }
                if (x is DBNull)
                {
                    return 0;
                }
                if (x.ToString() == "")
                {
                    return 0;
                }
                return int.Parse(x.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal DecimalForNull(object x)
        {
            try
            {
                if (x == null)
                {
                    return 0;
                }
                if (x is DBNull)
                {
                    return 0;
                }
                if (x.ToString() == "")
                {
                    return 0;
                }
                return decimal.Parse(x.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static DateTime DateTimeForNull(object x)
        {
            try
            {
                if (x == null)
                {
                    return DateTime.Now;
                }
                if (x is DBNull)
                {
                    return DateTime.Now;
                }
                if (x.ToString() == "")
                {
                    return DateTime.Now;
                }
                return (DateTime)x;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        #endregion
    }
}
