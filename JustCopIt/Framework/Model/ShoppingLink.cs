using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCopIt.Framework.Model
{
    public class ShoppingLink
    {
        public int OrderNo { set; get; }
        public string Url { set; get; }
        public string Size { set; get; }

        public string Size1
        {
            get
            {
                return Size + ".0";
            }
        }

        public string Size2
        {
            get
            {
                return "0" + Size;
            }
        }
        public string Size3
        {
            get
            {
                return "0" + Size + ".0";
            }
        }

        public Boolean Valid { set; get; }
    }
}
