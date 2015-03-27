using JustCopIt.Framework;
using JustCopIt.Framework.Model;

namespace JustCopIt.UserControls
{
   public interface ICartView
   {
       void ShowResult();
       void Clear();
       void Start(PageModel pageModel);
       void Stop();
   }
}
