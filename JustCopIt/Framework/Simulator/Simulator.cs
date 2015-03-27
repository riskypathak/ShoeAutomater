using System;
using System.Reflection;
using System.Windows.Forms;
using JustCopIt.Common;
using JustCopIt.Framework.Model;
using JustCopIt.Logging;
using JustCopIt.UserControls;

namespace JustCopIt.Framework.Simulator
{
    public delegate void TaskCompletedEventHandler(object sender, bool result);
   public abstract class Simulator
    {
       public event TaskCompletedEventHandler TaskCompletedEvent;
       protected readonly int _delayClickTime = Constants.DefaultSimulatorWaitingTime * 1000;
        //private readonly BackgroundWorker _navigator = new BackgroundWorker();
       protected readonly SimulatorView _simulatorView;
       protected readonly PageModel _pageModel;
       protected  string _url;
       protected UILog _spiderLogging;
       protected Simulator(UILog spiderLogging, SimulatorView simulatorView, PageModel pageModel)
       {
           _simulatorView = simulatorView;
           _pageModel = pageModel;
           _url = _pageModel.PageUrl;
           _spiderLogging = spiderLogging;
           //_navigator.DoWork += NavigatorDoWork;
       }

        protected bool StopFlage { get; set; }
       
       #region abstract methods

       protected abstract string FakeUrl(bool isRestart=false);

       protected abstract void SetSeletedSize();

       protected abstract bool CheckCompletedTask();

       #endregion

       public void Run()
       {
           StopFlage = false;
           int intervalBySecond = Constants.DefaultSimulatorWaitingTime;
           _simulatorView.PrepareDocument();
           _simulatorView.SetTimerInterval(intervalBySecond);
           _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, MethodBase.GetCurrentMethod().Name));
          _url= FakeUrl();
         StartSimulatorView(_url);
       }

       public void Clear()
       {
           StopFlage = true;
           _simulatorView.ClearDocument();
       }

       public void RunRestart()
       {
           StopFlage = false;
           var timer = new Timer();
           EventHandler checker = delegate
           {
               timer.Stop();
               timer.Dispose();

               if (StopFlage) return;
               _simulatorView.PrepareDocument();
               _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Run"));
               _url = FakeUrl(true);
               StartSimulatorView(_url);
           };
           timer.Tick += checker;
           timer.Interval = 10000;
           timer.Start();
        }
       
       public void Stop()
       {
           if (!StopFlage)
           {
               StopFlage = true;
               _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Stopped"));
           }
       }

       private void StartSimulatorView(string url)
       {
           if(StopFlage) return;
           _simulatorView.MainDocumentCompletedEvent -= OnMainDocumentCompletedEvent;
           _simulatorView.MainDocumentCompletedEvent += OnMainDocumentCompletedEvent;
           _simulatorView.NavigateToUrl(url);
       }

       private void OnMainDocumentCompletedEvent(object sender)
       {
           var sw = sender as SimulatorView;
           if (sw == null) return;
           sw.MainDocumentCompletedEvent -= OnMainDocumentCompletedEvent;

           if (StopFlage) return;

           _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Get document completed"));
           
           SetSeletedSize();
       }

      protected  bool ValidateSelectedSize(HtmlElement sizeEle)
       {
           return sizeEle.Enabled;
       }
       
       protected  bool ValidateProductByAddToCartStatus(HtmlElement addToCartElement)
       {
           return addToCartElement.Enabled;
       }

       protected void LogWrongSelectSize(int typeLog)
       {
           switch (typeLog)
           {
               case 1:
                   _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Cannot find the product size"));
                   break;
               case 2:
                   _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Cannot select the product size"));
                   break;
               case 3:
                   _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Cannot select the product size because it is out of stock."));
                   break;
           }
           ReportFail();
       }

       protected void ReportFail()
       {
           _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, " Fail - The requested item cannot be added to cart"));
           OnTaskCompletedEvent(false);
           _simulatorView.Finish();
       }
       
       protected void DelayRemoveFocusSelectedSize(HtmlElement ele, int miniseconds)
       {
           if (StopFlage) return;

           if (ele == null) return;
           var timer = new Timer();
           EventHandler checker = delegate
           {
               timer.Stop();
               timer.Dispose();

               if (StopFlage) return;
               ele.RemoveFocus();
               _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Selected size"));
               ClickAddToCart();
           };
           timer.Tick += checker;
           timer.Interval = miniseconds;
           timer.Start();
       }

       protected void ClickAddToCart()
       {
           if (StopFlage) return;

           var webBrowser = _simulatorView.WebSimulatorMainTab;
           if (webBrowser.Document != null)
           {
               var addToCartElement = webBrowser.Document.GetElementById(_pageModel.AddToCartClickElement.Name);
               if (addToCartElement != null)
               {
                   var style = addToCartElement.Style;
                   addToCartElement.Style = style + Constants.ModifiedColor;
                   addToCartElement.Focus();
                   if (ValidateProductByAddToCartStatus(addToCartElement))
                   {
                       DelayClickElement(addToCartElement, _delayClickTime);
                   }
                   else
                   {
                       _spiderLogging.Write(string.Format("{0} - {1} :{2}", _pageModel.Type, "This size is not available",_pageModel.SizeSetElement.Value));
                       ReportFail();
                   }
               }
           }
       }

       protected void DelayClickElement(HtmlElement ele, int miniseconds)
       {
           if (StopFlage) return;

           if (ele == null) return;
           var timer = new Timer();
           EventHandler checker = delegate
           {
               timer.Stop();
               timer.Dispose();
               
               if (StopFlage) return;

               _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Click Add to Cart"));
               _simulatorView.NavigateByLink(ele);
               FinishTask();
           };
           timer.Tick += checker;
           timer.Interval = miniseconds;
           timer.Start();
       }

       protected void FinishTask()
       {
           if (StopFlage) return;

           var timer = new Timer();
           EventHandler checker = delegate
           {
               timer.Stop();
               timer.Dispose();

               if (StopFlage) return;
               _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Check Task completely..."));
               var result = CheckCompletedTask();
               OnTaskCompletedEvent(result);
               //Navigate to ViewCart
               _simulatorView.MainDocumentCompletedEvent -= OnMainDocumentCompletedEvent;
               _simulatorView.NavigateToUrlManually(_pageModel.ViewCartUrl);
               _simulatorView.Finish();
           };
           timer.Tick += checker;
           timer.Interval = 4000;
           timer.Start();
       }

       private void OnTaskCompletedEvent(bool result)
       {
           TaskCompletedEventHandler handler = TaskCompletedEvent;
           if (handler != null)
           {
               handler(this,result);
           }

       }

     

    }
}
