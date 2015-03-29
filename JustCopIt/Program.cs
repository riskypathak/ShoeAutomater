using System;
using System.Windows.Forms;
using JustCopIt.Framework.Browser;
using JustCopIt.Views;
using JustCopIt.Common;

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
            Constants.IsReset = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BrowserEmulationHelper.SetBrowserEmulationMode(BrowserEmulationMode.IE_9);

            while (Constants.IsReset)
            {
                Application.Run(new MainForm());
            }
        }


    }
}
