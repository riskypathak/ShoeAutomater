using System;
using System.Text.RegularExpressions;

namespace JustCopIt.Util
{
   public class HtmlUtil
    {
        public static string InsertOrRepaceSizeParam(string url, string sizeValue, string appendChar="&")
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(sizeValue)) return url;

            var newSizeParm = string.Format("size={0}", sizeValue);
            var sizeParam = GetSizeFromUrl(url);
            if (string.IsNullOrEmpty(sizeParam))
            {
                //if (url.Contains("?"))
                //{
                //    return url.EndsWith("?") ? url + newSizeParm : url + "&" + newSizeParm;
                //}
                return url + appendChar + newSizeParm;
            }
            if (url.Contains("?" + sizeParam))
            {
                //var index = url.IndexOf("?" + sizeParam, StringComparison.Ordinal);
                //if (index > 0)
                //{
                //    var leftUrl = DataUtil.Left(url, index);
                //    if (leftUrl.Contains("?"))
                //    {
                //        return url.Replace("?"+sizeParam,"&"+ newSizeParm);    
                //    }
                //}
                return url.Replace("?" + sizeParam, appendChar + newSizeParm);  
            }
            return url.Replace(sizeParam, newSizeParm);
        }
        private static string GetSizeFromUrl(string url)
        {
            try
            {
                var result = Regex.Match(url, "size=([^&\"]*)");
                if (result.Groups.Count > 1)
                {
                    return result.Groups[0].Value;
                }

                return string.Empty;
            }
            catch (ArgumentException)
            {
                return string.Empty;
            }

        }

    }
}
