using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaMapping
{
    public class BaseKeys
    {
        public string Up { get; set; }
        public string Down { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
        public string Fire { get; set; }
        public string Select { get; set; }
        public string One { get; set; }
        public string Two { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }

        public virtual string ToString(bool includePrefix)
        {
            return base.ToString();
        }
    }
}
