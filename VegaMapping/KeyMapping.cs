using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VegaMapping
{
    public class KeyMapping: BaseKeys
    {
        public KeyMapping() { }

        public string StartSequence { get; set; }

        public KeyDescriptions Descriptions { get; set; }

        public override string ToString()
        {
            return ToString(false);
        }

        public override string ToString(bool includePrefix)
        {
            StringBuilder sb = new StringBuilder();
            string delimetor = ";";

            if (includePrefix)
            {
                sb.Append(string.Concat("K:", StartSequence));
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

        public bool Validate(ref string errors)
        {
            bool valid = true;
            List<string> inputs = new List<string>()
            {
                Up, Down, Left, Right, Fire, Select, One, Two, A, B, C
            };

            inputs.Sort();
            string strInputs = string.Join("", inputs);
            
            //TODO: Ignore blank input
            if (Regex.IsMatch(strInputs, @"(\w)\1+"))
            {
                valid = false;
                errors = "The same key has been defined more than once. ";
            }

            return valid;
        }

    }
}
