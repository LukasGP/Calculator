using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Token
    {
        public char _kind { get; set; }
        public double _value { get; set; }
        public bool _isEmpty { get; set; }

        /// <summary>
        /// Create a Token that represents iteslef.
        /// </summary>
        /// <param name="kind"></param>
        public Token(char kind)
        {
            _kind = kind;
            _value = double.NaN;
        }

        /// <summary>
        /// Create a token which has an associated value of type double.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="value"></param>
        public Token(char kind, double value)
        {
            _kind = kind;
            _value = value;
        }
    }
}
