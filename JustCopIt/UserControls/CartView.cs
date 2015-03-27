using System.ComponentModel;
using System.Windows.Forms;
using JustCopIt.Framework.Model;
using JustCopIt.Framework.Simulator;
using JustCopIt.Logging;

namespace JustCopIt.UserControls
{
    public partial class CartView : UserControl, ICartView
    {
        public event TaskCompletedEventHandler CartViewCompletedEvent;
        #region Declarations
        private Simulator _simulator;
        private readonly BackgroundWorker _navigator = new BackgroundWorker();
        #endregion

        
        public CartView()
        {
            InitializeComponent();
            _navigator.DoWork += NavigatorDoWork;
        }

        private void NavigatorDoWork(object sender, DoWorkEventArgs e)
        {
            var url = (string)(e.Argument);
            StartShowCartView(url);
        }

        //public string ViewCartUrl { get; set; }

        //public SiteType Type { get; set; }

        public UILog SpiderLogging { get; set; }

        private void StartShowCartView(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                //wbBrowser.Navigate(url);
            }
        }

     
        public void ShowResult()
        {
            //if (!_navigator.IsBusy)
            //{
            //    Clear();
            //    _navigator.RunWorkerAsync(ViewCartUrl);
            //}
        }

        public void Clear()
        {
            if (_simulator != null)
            {
               _simulator.Clear();
            }
        }

        private bool ValidatePageModel(PageModel pageModel)
        {
            if (pageModel == null) return false;
            return !string.IsNullOrEmpty(pageModel.PageUrl) && pageModel.AddToCartClickElement != null && pageModel.SizeSetElement != null;
        }

        public void Start( PageModel pageModel)
        {
            if (!ValidatePageModel(pageModel)) return;
            _simulator = SimulatorFactory.GetSimulator(SpiderLogging, spiderSimulator, pageModel);
            _simulator.TaskCompletedEvent+=Simulator_TaskCompletedEvent;
            _simulator.Run();

        }

        public void Restart()
        {
            if (_simulator != null)
            {
                _simulator.TaskCompletedEvent -= Simulator_TaskCompletedEvent;
                _simulator.TaskCompletedEvent += Simulator_TaskCompletedEvent;
                _simulator.RunRestart();
            }
            

        }

        private void Simulator_TaskCompletedEvent(object sender, bool result)
        {
            var sl = sender as Simulator;
            if (sl == null) return;
            sl.TaskCompletedEvent -= Simulator_TaskCompletedEvent;
            OnCartViewCompletedEvent(result);
        }

        private void OnCartViewCompletedEvent(bool result)
        {
            TaskCompletedEventHandler handler = CartViewCompletedEvent;
            if (handler != null)
            {
                handler(this, result);
            }

        }

        public void Stop()
        {
            if (_simulator != null)
            {
                _simulator.Stop();
            }
        }
    }
}
