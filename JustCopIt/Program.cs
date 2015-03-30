using System;
using System.Windows.Forms;
using JustCopIt.Framework.Browser;
using JustCopIt.Views;
using JustCopIt.Common;
using System.Diagnostics;

namespace JustCopIt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Constants.IsReset = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BrowserEmulationHelper.SetBrowserEmulationMode(BrowserEmulationMode.IE_9);
            var mainForm = new MainForm { TopMost = true };
            Application.Run(mainForm);
            while (Constants.IsReset)
            {
                Process.Start(Application.StartupPath + "\\JustCopIt.exe");

                //close this one
                Process.GetCurrentProcess().Kill();
            }
        }


    }
}
