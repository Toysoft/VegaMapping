using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaMapping
{
    public class KeyDescriptions : BaseKeys
    {

        public override string ToString(bool includePrefix)
        {
            StringBuilder sb = new StringBuilder();
            string delimetor = ";";

            if (includePrefix)
            {
                sb.Append("D:");
            }
                
            sb.Append(string.Concat(delimetor, Up));
            sb.Append(string.Concat(delimetor, Down));
            sb.Append(string.Concat(delimetor, Left));
            sb.Append(string.Concat(delimetor, Right));

            sb.Append(string.Concat(delimetor, Fire));
            sb.Append(string.Concat(delimetor, Select));
            sb.Append(string.Concat(delimetor, One));
            sb.Append(string.Concat(delimetor, Two));

            if (string.Concat(A, B, C).Length > 0)
            {
                sb.Append(string.Concat(delimetor, A));
                sb.Append(string.Concat(delimetor, B));
                sb.Append(string.Concat(delimetor, C));
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToString(false);
        }
    }
}
