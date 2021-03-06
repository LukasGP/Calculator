﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace Calculator
{
    public class Token_stream:IToken_stream
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
            var ch = _input[0];
            if (_input.Length.Equals(0))
            {
                Console.WriteLine("No input to evaluate");
                return new Token(';');
            }
            
            if ((ch >= '0' && ch <= '9') || ch == '.')
            {
                // We've detected a number, now we need to gather the entire value.
                var strBuilder = new StringBuilder();
                strBuilder.Append(ch.ToString());

                int tmp_index = 1;
                if (_input.Length > 1)
                {
                    while (tmp_index < _input.Length && ((_input[tmp_index] >= '0' && _input[tmp_index] <= '9') || _input[tmp_index] == '.'))
                    {
                        strBuilder.Append(_input[tmp_index]);
                        tmp_index++;
                    }
                }
                    
                // Capture the number
                var whole_number = float.Parse(strBuilder.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                // Remove all characters which were associated with that number so we don't evaluate them again.
                int number_of_characters = tmp_index;
                Console.WriteLine($"Found number {whole_number}, Removing {number_of_characters} from input");

                _input = _input.Remove(0, tmp_index);
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
                    _input = _input.Remove(0, 1);
                    return new Token(ch);
                default:
                    throw new Exception("Bad Input");
            }
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
