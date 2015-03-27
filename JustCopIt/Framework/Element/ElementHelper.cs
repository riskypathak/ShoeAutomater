using JustCopIt.Common;
using JustCopIt.Enumeration;

namespace JustCopIt.Framework.Element
{
   public class ElementHelper
    {
       public static SetElement GetSizeElement(SiteType type, string value)
       {
           switch (type)
           {
               case SiteType.ChampsSports:
                   return new SetElement(ConfigElement.ChamsSports_ProductSizeID, value);
               case SiteType.Eastbay:
                   return new SetElement(ConfigElement.Eastbay_SizeID, value);
               case SiteType.Footaction:
                   return new SetElement(ConfigElement.Footaction_SizeID, value);
               case SiteType.FootLocker:
                   return new SetElement(ConfigElement.FootLocker_ProductSizeID, value);
           }
           return null;
       }

       public static SetElement GetSelectedSizeDisplayElement(SiteType type, string value)
       {
           switch (type)
           {
               case SiteType.ChampsSports:
                   return new SetElement(ConfigElement.ChamsSports_SelectedSizeDisplay, value);
               case SiteType.Eastbay:
                   return new SetElement(ConfigElement.Footaction_SelectedSizeDisplay, value);
               case SiteType.Footaction:
                   return new SetElement(ConfigElement.Footaction_SelectedSizeDisplay, value);
               case SiteType.FootLocker:
                   return new SetElement(ConfigElement.FootLocker_SelectedSizeDisplay, value);
           }
           return null;
       }

       public static ClickElement GetClickElement(SiteType type)
       {
           switch (type)
           {
               case SiteType.ChampsSports:
                   return new ClickElement(ConfigElement.ChamsSports_AddToCartID);
               case SiteType.Eastbay:
                   return new ClickElement(ConfigElement.Eastbay_AddToCartID);
               case SiteType.Footaction:
                   return new ClickElement(ConfigElement.Footaction_AddToCartID);
               case SiteType.FootLocker:
                   return new ClickElement(ConfigElement.FootLocker_AddToCartID);
           }
           return null;
       }

       public static CheckElement GetCheckResultElement(SiteType type)
       {
           switch (type)
           {
               case SiteType.ChampsSports:
                   return new CheckElement(ConfigElement.ChamsSports_CheckResultID);
               case SiteType.Eastbay:
                   return new CheckElement(ConfigElement.Eastbay_CheckResultID);
               case SiteType.Footaction:
                   return new CheckElement(ConfigElement.Footaction_CheckResultID);
               case SiteType.FootLocker:
                   return new CheckElement(ConfigElement.FootLocker_CheckResultID);
           }
           return null;
       }
    }
}
