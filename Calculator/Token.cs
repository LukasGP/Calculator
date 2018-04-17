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
        public string _name { get; set; }
        public double _value { get; set; }
        public bool _isEmpty { get; set; }

        public Token(char kind)
        {
            _kind = kind;
            _value = double.NaN;
        }

        public Token(char kind, double value)
        {
            _kind = kind;
            _value = value;
        }

        public Token(char kind, string name)
        {
            _kind = kind;
            _name = name;
            _value = double.NaN;
        }
    }
}
