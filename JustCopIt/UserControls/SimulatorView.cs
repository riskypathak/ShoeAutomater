
using System;
using System.Windows.Forms;
using JustCopIt.Common;

namespace JustCopIt.UserControls
{
    public delegate void MainDocumentCompletedEventHandler(object sender);

    public partial class SimulatorView : UserControl
    {
        public event MainDocumentCompletedEventHandler MainDocumentCompletedEvent;
        private  int _waitingTime = Constants.DefaultSimulatorWaitingTime;
        private readonly int _maxTimes = Constants.DefaultSimulatorTickTimes;
        private const int ExtraTime = 2;
        private int _iTick;

        public SimulatorView()
        {
            InitializeComponent();
        }

        public WebBrowser WebSimulatorMainTab
        {
            get { return webSimulatorMainTab; }
        }

        #region Set up Timer

        private void SetUpTimer()
        {
            StopTimer();
            trackingTimer.Interval = (_waitingTime + ExtraTime)*1000;
        }

        private void StartTimer()
        {
            _iTick = 0;
            trackingTimer.Start();
        }

        private void StopTimer()
        {
            _iTick = 0;
            trackingTimer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _iTick += 1;
            var timer = (Timer)sender;
            if (webSimulatorMainTab.Document != null && webSimulatorMainTab.ReadyState == WebBrowserReadyState.Complete)
            {
                timer.Stop();
                _iTick = 0;

                OnMainDocumentCompletedEvent();
            }
            else if (_iTick >= _maxTimes)
            {
                timer.Stop();
                _iTick = 0;
                OnMainDocumentCompletedEvent();
            }
        }

        #endregion

        private void OnMainDocumentCompletedEvent()
        {
            MainDocumentCompletedEventHandler handler = MainDocumentCompletedEvent;
            if (handler != null)
            {
                handler(this);
            }

        }

        public void SetTimerInterval(int value)
        {
            _waitingTime = value <= 0 ? Constants.DefaultSimulatorWaitingTime : value;
            trackingTimer.Interval = (_waitingTime + ExtraTime) * 1000;
            
        }

        public void Finish()
        {
            StopTimer();
        }

        public void NavigateToUrl(string strUrl)
        {
            StartTimer();
            txtNavigateUrl.Text = strUrl;
            webSimulatorMainTab.Navigate(strUrl);
        }

        public void NavigateToUrlManually(string strUrl)
        {
           StopTimer();
            txtNavigateUrl.Text = strUrl;
            if (webSimulatorMainTab.Document != null)
            {
                webSimulatorMainTab.Document.Cookie = null;
            }
            webSimulatorMainTab.Navigate(strUrl);
        }

        public void NavigateByLink(HtmlElement element)
        {
            try
            {
                StartTimer();
                element.InvokeMember("click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void SelectElement(HtmlElement element)
        {
            try
            {
                element.InvokeMember("onchange");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void PrepareDocument()
        {
            webSimulatorMainTab.Stop();
            if (webSimulatorMainTab.Document != null)
            {
                webSimulatorMainTab.Document.OpenNew(true);
            }
        }
        public void ClearDocument()
        {
            PrepareDocument();
            webSimulatorMainTab.Navigate("about:blank");
        }

        #region Events

        private void SimulatorView_Load(object sender, EventArgs e)
        {
            SetUpTimer();
        }

        private void webSimulatorMainTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        #endregion

       
       

    }
}
