using System.Collections.Generic;

namespace JustCopIt.Common
{
    class SizeSource:List<string>
    {
        private static List<string> _data;

        public static List<string> Data
        {
            get { return _data ?? (_data = GetSizes()); }
        }

        private static List<string> GetSizes()
        {
            var sizes = new List<string>();
            for (var i = 3; i <= 18; i++)
            {
                var value1 = string.Format("{0}.0", i);
                var value2 = string.Format("{0}.5", i);
                if (i < 10)
                {
                    sizes.Add("0" +value1);
                    sizes.Add("0" + value2);
                }
                else
                {
                    sizes.Add(value1);
                    sizes.Add(value2);
                }
            }
            sizes.RemoveAt(sizes.Count-1);
            sizes.RemoveAt(0);
            return sizes;
        }
    }
}
