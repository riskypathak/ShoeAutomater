using System;
using System.Windows.Forms;

namespace JustCopIt.Logging
{
   public class UILogging
    {
       private readonly RichTextBox _controlLog;
       public UILogging(RichTextBox controlLog)
        {
            _controlLog = controlLog;
           
        }
           public void Write(string message)
           {
               _controlLog.Text += DateTime.Now.ToString("HH:mm:ss") + @": " + message + Environment.NewLine;
               _controlLog.SelectionStart = _controlLog.Text.Length;
               _controlLog.ScrollToCaret();
               
           }
    }
}
