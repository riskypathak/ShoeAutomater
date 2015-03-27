using JustCopIt.Enumeration;
using JustCopIt.Util;

namespace JustCopIt.Framework.Model
{
   public class SiteModel
    {
        public SiteType Type { get; set; }
        public bool IsValid { get; set; }
        public string SiteUrl { get; set; }
        public string Size { get; set; }
        public PageModel PageModel { get; set; }

        public SiteModel(SiteType siteType, bool isValid, string siteUrl, string size)
        {
            Type = siteType;
            IsValid = isValid;
            SiteUrl = siteUrl;
            Size = size;
            PageModel = PageModelFactory.GetPageModel(Type, SiteUrl, Size);
        }

        public bool IsPageModel()
        {
            if (PageModel == null) return false;
            return !DataUtil.IsNullOrEmptyOrWhiteSpace(PageModel.PageUrl) && PageModel.AddToCartClickElement != null && PageModel.SizeSetElement != null;
        }

    }
}
