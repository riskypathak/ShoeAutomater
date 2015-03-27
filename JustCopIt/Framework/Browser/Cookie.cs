using System;
using System.Runtime.InteropServices;
using System.Text;

namespace JustCopIt.Framework.Browser
{

    public class Cookies
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
        const int INTERNET_COOKIE_HTTPONLY = 0x00002000;

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string lpszUrlName, string lpszCookieName, string lpszCookieData);

        public static string GetGlobalCookies(string uri)
        {
            uint datasize = 1024;
            var cookieData = new StringBuilder((int)datasize);
            if (InternetGetCookieEx(uri, null, cookieData, ref datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero)
                && cookieData.Length > 0)
            {
                return cookieData.ToString().Replace(';', ',');
            }
            return null;
        }

        public static void SetGlobalCookies(string uri, string name, string data)
        {
            InternetSetCookie(uri, name, data);
            
        }

    }
}
