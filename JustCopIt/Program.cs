using System;
using System.Windows.Forms;
using JustCopIt.Framework.Browser;
using JustCopIt.Views;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BrowserEmulationHelper.SetBrowserEmulationMode(BrowserEmulationMode.IE_9);
            Application.Run(new MainForm());
        }


    }
}
