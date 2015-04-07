using System;
using System.Windows.Forms;
using JustCopIt.Common;
using JustCopIt.Framework.Model;
using JustCopIt.Logging;
using JustCopIt.UserControls;
using JustCopIt.Util;

namespace JustCopIt.Framework.Simulator
{
    public class ChampsSportsSimulator : Simulator
    {
        public ChampsSportsSimulator(UILogging spiderLogging,SimulatorView simulatorView, PageModel pageModel)
            : base(spiderLogging,simulatorView, pageModel)
        {

        }
        protected override string FakeUrl(bool isRestart = false)
        {
            return HtmlUtil.InsertOrRepaceSizeParam(_pageModel.PageUrl, _pageModel.SizeSetElement.Value,"?");
        }
        protected override void SetSeletedSize()
        {
            if (StopFlage) return;

            try
            {
                var webBrowser = _simulatorView.WebSimulatorMainTab;
                if (webBrowser.Document != null)
                {
                    var productSizesElement = webBrowser.Document.GetElementById(_pageModel.SizeSetElement.Name);
                    if (productSizesElement != null)
                    {
                        var style = productSizesElement.Style;
                        productSizesElement.Style = style + Constants.ModifiedColor;
                        productSizesElement.Focus();
                        _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, "Selecting size"));

                        if (!string.IsNullOrEmpty(productSizesElement.InnerText) && productSizesElement.InnerText.Contains(_pageModel.SizeSetElement.Value))
                        {
                            if (ValidateSelectedSize(productSizesElement))
                            {
                                DelayRemoveFocusSelectedSize(productSizesElement, 500);
                            }
                            else
                            {
                                LogWrongSelectSize(3);
                            }
                        }
                        else
                        {
                            LogWrongSelectSize(2);
                        }
                    }
                    else
                    {
                        LogWrongSelectSize(1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override bool CheckCompletedTask()
        {
            if (StopFlage) return false;

            var webBrowser = _simulatorView.WebSimulatorMainTab;
            if (webBrowser.Document == null) return false;
            //check order_summary
            var order = webBrowser.Document.GetElementById("order_summary");
            if (order != null && !string.IsNullOrEmpty(order.InnerText))
            {
                if (order.InnerText.ToLower().Contains("1"))
                {
                    _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, @"SUCCESS - The requested item added to cart successfully."));
                    return true;
                }
            }
            //some link show popup
            var checkElement = webBrowser.Document.GetElementById(_pageModel.CheckElement.Name);
            if (checkElement != null )
            {
                _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, @"SUCCESS - The requested item added to cart successfully."));
                return true;
            }
            _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, @"Fail - The requested item cannot be added to cart because it is out of stock."));
            return false;
        }
    }
}
