using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace Calculator
{
    class Token_stream
    {
        private bool _full;
        private Token _buffer;
        public string _input; // A copy of the input that will be evaluated and trimmed one character at a time.
        public string _query; // A copy of the input for display purposes.

        public Token_stream()
        {
            _full = false;
            _buffer = null;
            _input = null;
        }

        public Token_stream(string input)
        {
            _full = false;
            _buffer = null;
            _input = input;
            _query = input;
        }

        public Token Get()
        {
            if (_full)
            {
                _full = false;
                Console.WriteLine($"Getting Token:{_buffer._kind}:{_buffer._value}");
                return _buffer;
            }

            if (_input.Equals(null))
            {
                throw new Exception("Unable to process empty input.");
            }

            else if (_input.Length != 0)
            {
                var found_token = Evaluate_Input();
                Console.WriteLine($"Getting Token:{found_token._kind}:{found_token._value}");
                return found_token;
            }
            return new Token(';');
        }

        private Token Evaluate_Input()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                var ch = _input[i];
                // TODO: Handle numeric input
                if ((ch >= '0' && ch <= '9') || ch == '.')
                {
                    // We've detected a number, now we need to gather the entire value.
                    var strBuilder = new StringBuilder();
                    strBuilder.Append(ch.ToString());

                    int tmp_index = i + 1;
                    if (_input.Length > 1)
                    {
                        while (_input[tmp_index] >= 0 && _input[tmp_index] <= 9)
                        {
                            strBuilder.Append(_input[tmp_index]);
                            tmp_index++;
                        }
                    }
                    
                    // Capture the number
                    var whole_number = float.Parse(strBuilder.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                    // Remove all characters which were associated with that number so we don't evaluate them again.
                    int number_of_characters = tmp_index - i;
                    Console.WriteLine($"Found number {whole_number}, Removing {number_of_characters} from input");

                    _input = _input.Remove(i, tmp_index - i);
                    return new Token('n', whole_number);
                }

                // Let these characters represent themselves
                switch (ch)
                {
                    case 'q':
                    case 'p':
                    case '(':
                    case ')':
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '%':
                    case '=':
                        _input = _input.Remove(i, i + 1);
                        return new Token(ch);
                    default:
                        throw new Exception("Bad Input");
                }
            }
            Console.WriteLine("No Input Provided");
            return new Token(';');
        }

        /// <summary>
        /// Store a token in buffer for future evaluation.
        /// </summary>
        /// <param name="t"></param>
        public void Putback(Token t)
        {
            if (_full)
                throw new Exception("Attempted to put item back into a full buffer.");
            Console.WriteLine($"Storing Token in buffer:{t._kind}:{t._value}");
            _buffer = t;
            _full = true;
        }
    }
}
