using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCopIt.Common
{
  public  class MockData
    {
        public const string ChampsSportsHost = "http://www.champssports.com";
        public const string EastbayViewHost = "http://www.eastbay.com";
        public const string FootactioHost = "http://www.footaction.com";
        public const string FootLockerHost = "http://www.footlocker.com";

      public const string ChampsSportsUrl = "http://www.champssports.com/product/model:98963/sku:24300657/nike-air-force-1-low-mens/all-white/white/";
      public const string EastbayUrl = "http://www.eastbay.com/product/model:224556/sku:5945A/timberland-kick-around-low-moc-mens/brown/tan/";
      public const string FootactionUrl = "http://www.footaction.com/product/model:25338/sku:99474050/nike-acg-air-max-goadome-mens/all-black/black/";
      public const string FootLockerUrl = "http://www.footlocker.com/product/model:234213/sku:11046004/jordan-dub-zero-mens/black/white/?cm=searchmensbasketballshoes/";
      //&size= : FootLockerUrl+EastbayUrl+FootactionUrl
      //?size=09.0 : ChampsSportsUrl
      public const string ChampsSportsDefaultSize = "17.0";
      public const string EastbayDefaultSize = "10.0";
      public const string FootactionDefaultSize = "08.0";
      public const string FootLockerDefaultSize = "09.0";

      public const string ChampsSportsViewCartUrl = "http://www.champssports.com/shoppingcart/default.cfm";
      public const string EastbayViewCartUrl = "http://www.eastbay.com/shoppingcart/default.cfm";
      public const string FootactionViewCartUrl = "http://www.footaction.com/shoppingcart/default.cfm";
      public const string FootLockerViewCartUrl = "http://www.footlocker.com/shoppingcart/default.cfm";
    }
}
