using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace JustCopIt.Logging
{

    public class UILog
    {
        private class UILogMessage
        {
            public readonly string Message;
            public readonly RichTextBox ControlLog;


            public UILogMessage(string message, RichTextBox controlLog)
            {
                Message = message;
                ControlLog = controlLog;
            }
        };

        private readonly Queue _firstQueue = new Queue();
        private readonly Queue _secondQueue = new Queue();
        private Queue _currentQueue;
       private static UILog _singleton;
        private readonly AutoResetEvent _dataReadyFlag = new AutoResetEvent( false );
        private readonly Mutex _queueAccessFlag = new Mutex();
        private readonly Thread _writingThread = new Thread( WritingWorker );
        private readonly RichTextBox _controlLog;
        
        public UILog(RichTextBox controlLog)
        {
            _writingThread.Priority = ThreadPriority.Lowest;
            _currentQueue = _firstQueue;
            _controlLog = controlLog;
            if (_singleton == null)
            {
                _singleton = this;
                _singleton._writingThread.Start();
            }
        }

        public  void Write(string message)
        {
            if (_singleton != null)
            {
                _singleton.PushMessage(message, _singleton._controlLog);
            }
        }
        public void StopLogging()
        {
            if (_singleton != null)
            {
                _singleton._writingThread.Abort();
            }
        }


        private void PushMessage(string message, RichTextBox controlLog)
        {
            _queueAccessFlag.WaitOne();
            _currentQueue.Enqueue(new UILogMessage(message, controlLog));
            _dataReadyFlag.Set();
            _queueAccessFlag.ReleaseMutex();
        }

        private static void WritingWorker( object obj )
        {
            while (true)
            {
                _singleton._dataReadyFlag.WaitOne();
                _singleton._queueAccessFlag.WaitOne();
                _singleton._dataReadyFlag.Reset();
                //swap the 2 buffer
                var tempQueue = _singleton._currentQueue;
                _singleton._currentQueue = _singleton._currentQueue == _singleton._firstQueue ? _singleton._secondQueue : _singleton._firstQueue;
                _singleton._queueAccessFlag.ReleaseMutex();

                while (tempQueue.Count > 0)
                {
                    var logMessage = (UILogMessage)tempQueue.Dequeue();
                    logMessage.ControlLog.Invoke((MethodInvoker)(() => 
                        logMessage.ControlLog.Text +=  DateTime.Now.ToString( "HH:mm:ss" )+ @": "+ logMessage.Message +Environment.NewLine  ));
                    logMessage.ControlLog.Invoke((MethodInvoker)(() =>
                        logMessage.ControlLog.SelectionStart = logMessage.ControlLog.Text.Length));
                    logMessage.ControlLog.Invoke((MethodInvoker)(() =>
                        logMessage.ControlLog.ScrollToCaret()));
                }
            }
        }

    }
}
