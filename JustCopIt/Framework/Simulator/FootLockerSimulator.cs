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
   public class FootLockerSimulator:Simulator
    {
       public FootLockerSimulator(UILogging spiderLogging, SimulatorView simulatorView, PageModel pageModel)
           : base(spiderLogging,simulatorView, pageModel)
       {
           
       }
       protected override string FakeUrl(bool isRestart = false)
       {
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
                           var found = false;
                           HtmlElementCollection htmlElementCollection = productSizesElement.Children;
                           foreach (HtmlElement elem in htmlElementCollection)
                           {
                               string elemName = elem.InnerText;
                               if (!string.IsNullOrEmpty(elemName) && elemName.Contains(_pageModel.SizeSetElement.Value))
                               {
                                   if (ValidateSelectedSize(elem))
                                   {
                                       found = true;
                                       productSizesElement.SetAttribute("value", _pageModel.SizeSetElement.Value);
                                       productSizesElement.RemoveFocus();
                                       DelayRemoveFocusSelectedSize(productSizesElement, 500);
                                   }
                                   break;
                               }
                           }
                           if (!found)
                           {
                               LogWrongSelectSize(2);
                           }
                       }
                       else
                       {
                           LogWrongSelectSize(1);
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
           if (webBrowser.Document != null)
           {
               //check order_summary
               var order = webBrowser.Document.GetElementById("order_summary");
               if (order != null && !string.IsNullOrEmpty(order.InnerText))
               {
                   if (order.InnerText.ToLower().Contains("1 item"))
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
