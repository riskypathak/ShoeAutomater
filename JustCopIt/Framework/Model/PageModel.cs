using JustCopIt.Common;
using JustCopIt.Enumeration;
using JustCopIt.Framework.Element;

namespace JustCopIt.Framework.Model
{
   public class PageModel
   {
       
       public PageModel(string url)
        {
            PageUrl = url;
        }

       public SiteType Type { get; set; }

        public string PageUrl { get; set; }
       
       public SetElement SizeSetElement { get; set; }

        public SetElement SelectedSizeDisplaySetElement { get; set; }

        public ClickElement AddToCartClickElement { get; set; }

        public CheckElement CheckElement { get; set; }

        public string ViewCartUrl { get; set; }

        public string CookieName { get; set; }

    }

   public class PageModelFactory
   {
       public static PageModel GetPageModel(SiteType type, string url, string value)
       {
           switch (type)
           {
               case SiteType.ChampsSports:
                   return new PageModel(url)
                    {
                        Type = type,
                        SizeSetElement = new SetElement(ConfigElement.ChamsSports_ProductSizeID, value),
                        SelectedSizeDisplaySetElement = new SetElement(ConfigElement.ChamsSports_SelectedSizeDisplay, value),
                        AddToCartClickElement = new ClickElement(ConfigElement.ChamsSports_AddToCartID),
                        CheckElement = new CheckElement(ConfigElement.ChamsSports_CheckResultID),
                        ViewCartUrl=ConfigElement.ChampsSports_ViewCartUrl,
                        CookieName = ConfigElement.ChamsSports_CookieName
                    };
               case SiteType.Eastbay:
                   return new PageModel(url)
                    {
                        Type = type,
                        SizeSetElement = new SetElement(ConfigElement.Eastbay_SizeID, value),
                        SelectedSizeDisplaySetElement = new SetElement(ConfigElement.Footaction_SelectedSizeDisplay, value),
                        AddToCartClickElement = new ClickElement(ConfigElement.Eastbay_AddToCartID),
                        CheckElement = new CheckElement(ConfigElement.Footaction_CheckResultID),
                        ViewCartUrl = ConfigElement.Eastbay_ViewCartUrl,
                        CookieName = ConfigElement.Eastbay_CookieName
                    };
               case SiteType.Footaction:
                   return new PageModel(url)
                    {
                        Type = type,
                        SizeSetElement = new SetElement(ConfigElement.Footaction_SizeID, value),
                        SelectedSizeDisplaySetElement = new SetElement(ConfigElement.Footaction_SelectedSizeDisplay, value),
                        AddToCartClickElement = new ClickElement(ConfigElement.Footaction_AddToCartID),
                        CheckElement = new CheckElement(ConfigElement.Footaction_CheckResultID),
                        ViewCartUrl = ConfigElement.Footaction_ViewCartUrl,
                        CookieName = ConfigElement.Footaction_CookieName
                    };
               case SiteType.FootLocker:
                   return new PageModel(url)
                    {
                        Type = type,
                        SizeSetElement = new SetElement(ConfigElement.FootLocker_ProductSizeID, value),
                        SelectedSizeDisplaySetElement = new SetElement(ConfigElement.FootLocker_SelectedSizeDisplay, value),
                        AddToCartClickElement = new ClickElement(ConfigElement.FootLocker_AddToCartID),
                        CheckElement = new CheckElement(ConfigElement.FootLocker_CheckResultID),
                        ViewCartUrl = ConfigElement.FootLocker_ViewCartUrl,
                        CookieName = ConfigElement.FootLocker_CookieName
                    };
           }
           return null;
          
       }

   }
}
