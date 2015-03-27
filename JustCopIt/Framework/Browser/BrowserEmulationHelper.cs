using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace JustCopIt.Framework.Browser
{
    class BrowserEmulationMode
    {
        public static UInt32 IE_11 = 11000;
        public static UInt32 IE_10 = 10000;
        public static UInt32 IE_9 = 9000;
        public static UInt32 IE_8_Standards_Mode_Forced = 8888;
        public static UInt32 IE_8_Standards_Mode = 8000;
        public static UInt32 IE_7_Standards_Mode = 70000;
    }

    class BrowserEmulationHelper
    {

        public static void SetBrowserEmulationMode(UInt32 mode)
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            string fileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", StringComparison.OrdinalIgnoreCase) == 0 ||
                String.Compare(fileName, "XDesProc.exe", StringComparison.OrdinalIgnoreCase) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, mode);
        }

        public static void SetBrowserFeatureControl()
        {

            // FeatureControl settings are per-process
            var fileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", StringComparison.OrdinalIgnoreCase) == 0 ||
                String.Compare(fileName, "XDesProc.exe", StringComparison.OrdinalIgnoreCase) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode());
          
        }

        public static void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            try
            {
                string subKeyName = String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature);

                // HKEY_CURRENT_USER
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    if (key != null) key.SetValue(appName, value, RegistryValueKind.DWord);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"SetBrowserFeatureControlKey: " + ex.Message);
            }
        }

        /// <summary>
        /// Get Version of IE in Client
        /// </summary>
        /// <returns></returns>
        public static UInt32 GetBrowserEmulationMode()
        {
            var browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                if (ieKey != null)
                {
                    var version = ieKey.GetValue("svcVersion");
                    if (null == version)
                    {
                        version = ieKey.GetValue("Version");
                        if (null == version)
                            throw new ApplicationException("Microsoft Internet Explorer is required!");
                    }
                    int.TryParse(version.ToString().Split('.')[0], out browserVersion);
                }
            }

            UInt32 mode;
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
                    break;
            }

            return mode;
        }
    }
}
