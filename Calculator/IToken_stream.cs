using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    interface IToken_stream
    {
        Token Get();
        void Putback(Token t);
    }
}
