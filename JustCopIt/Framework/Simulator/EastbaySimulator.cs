using System;
using System.Reflection;
using System.Windows.Forms;
using JustCopIt.Common;
using JustCopIt.Framework.Model;
using JustCopIt.Logging;
using JustCopIt.UserControls;
using JustCopIt.Util;

namespace JustCopIt.Framework.Simulator
{
 

    public class EastbaySimulator : Simulator
    {
        public EastbaySimulator(UILog spiderLogging,SimulatorView simulatorView, PageModel pageModel)
            : base(spiderLogging,simulatorView, pageModel)
        {

        }

        protected override string FakeUrl(bool isRestart = false)
        {
            if (isRestart)
            {
                if (_pageModel.PageUrl.Contains("?cm=") && _pageModel.PageUrl.Contains("#sku-"))
                {
                    return _pageModel.PageUrl;
                }
            }
            return HtmlUtil.InsertOrRepaceSizeParam(_pageModel.PageUrl, _pageModel.SizeSetElement.Value);
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
                                DelayRemoveFocusSelectedSize(productSizesElement, 1500);    
                            }
                            else
                            {
                                LogWrongSelectSize(3);
                            }
                        }
                        else
                        {
                            _simulatorView.NavigateByLink(productSizesElement);
                            DelayAfterClickProductSize(productSizesElement, 1500);
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


        protected void DelayAfterClickProductSize(HtmlElement ele, int miniseconds)
        {
            if (StopFlage) return;

            if (ele == null) return;
            var timer = new Timer();
            EventHandler checker = delegate
            {
                timer.Stop();
                timer.Dispose();

                if (StopFlage) return;
                var productSizesElement = ele;
                var webBrowser = _simulatorView.WebSimulatorMainTab;
                if (webBrowser.Document != null)
                {
                    HtmlElementCollection hrefElementCollection = productSizesElement.GetElementsByTagName("a");
                    if (hrefElementCollection.Count <= 0)
                    {
                        LogWrongSelectSize(2);
                        return;
                    }
                    var found = false;
                    foreach (HtmlElement sizeEle in hrefElementCollection)
                    {
                        var elemName = sizeEle.InnerText;
                        if (!string.IsNullOrEmpty(elemName) && elemName.Contains(_pageModel.SizeSetElement.Value))
                        {
                            var styleHref = sizeEle.Style;
                            sizeEle.Style = styleHref + Constants.ModifiedColor;
                            sizeEle.Focus();
                            var selectedEle = webBrowser.Document.GetElementById(_pageModel.SelectedSizeDisplaySetElement.Name);
                            if (selectedEle != null)
                            {
                                selectedEle.InnerText = _pageModel.SizeSetElement.Value;
                                selectedEle.Focus();
                            }
                            if (ValidateSelectedSize(sizeEle))
                            {
                                found = true;
                                DelayRemoveFocusSelectedSize(selectedEle, 1500);
                            }
                            break;
                        }
                    }
                    if (!found)
                    {
                        LogWrongSelectSize(2);
                    }
                }
                
            };
            timer.Tick += checker;
            timer.Interval = miniseconds;
            timer.Start();
        }

        protected override bool CheckCompletedTask()
        {
            if (StopFlage) return false;

            var webBrowser = _simulatorView.WebSimulatorMainTab;
            if (webBrowser.Document != null)
            {
                //check order_summary
                var order = webBrowser.Document.GetElementById("order_summary");
                if (order != null && !string.IsNullOrEmpty(order.InnerText))
                {
                    if (order.InnerText.ToLower().Contains("items: 1"))
                    {
                        _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, @"SUCCESS - The requested item added to cart successfully."));
                        return true;
                    }
                }
                //some link show miniAddToCartWin
                var checkElement = webBrowser.Document.GetElementById(_pageModel.CheckElement.Name);
                if (checkElement != null && !string.IsNullOrEmpty(checkElement.InnerText))
                {
                    var text = checkElement.InnerText.ToLower();
                    if (text.Contains("subtotal:"))
                    {
                        _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, @"SUCCESS - The requested item added to cart successfully."));
                        return true;
                    }
                    if (text.Contains("out of stock"))
                        _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, @"Fail - The requested item cannot be added to cart because it is out of stock."));
                    return false;
                }
                _spiderLogging.Write(string.Format("{0} - {1}", _pageModel.Type, @"Fail - The requested item cannot be added to cart because it is out of stock or wrongly selected size."));
                return false;
            }
            return false;
        }
    }
}
