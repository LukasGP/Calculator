using Calculator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace Calculator
{
    public class Calculator_Core
    {

        Token_stream ts;
        public Calculator_Core() { }

        /// <summary>
        /// Get the input for the stored command url and run calculate to determine the result.
        /// </summary>
        /// <returns>
        /// Tuple<string,double>
        ///    -- Item1 is the input text
        ///    -- Item2 is the calculated result
        /// </returns>
        /// </returns>
        public Tuple<string, double> CalculateFromUrl(string commandurl)
        {
            var input = GetInputFromUrl(commandurl);
            return CalculateFromString(input);
        }

        /// <summary>
        /// From the given input calculate the result.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// Tuple<string,double>
        ///    -- Item1 is the input text
        ///    -- Item2 is the calculated result
        /// </returns>
        public Tuple<string, double> CalculateFromString(string input)
        {
            SetInput(input);
            while (ts._input.Length != 0)
            {
                var t = ts.Get();
                while (t._kind == 'p') t = ts.Get();     // get through all prints
                if (t._kind == 'q') return null;    // quit
                ts.Putback(t);
                var result = Expression();
                Console.WriteLine($"result is: {result}");
                return new Tuple<string, double>(input, result);
            }
            return null;
        }

        /// <summary>
        /// Create a token stream based off of the input string.
        /// </summary>
        /// <param name="input"></param>
        public void SetInput(string input)
        {
            ts = new Token_stream(input);
        }

        /// <summary>
        /// Get input from the designated url and turn into a format consumable by our calculator.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetInputFromUrl(string url)
        {
            // Fetch JSON string
            string input_string = "";
            try
            {
                using (var wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    Console.WriteLine(json);
                    using (var sr = new StringReader(json))
                    using (var jr = new JsonTextReader(sr))
                    {
                        var js = new JsonSerializer();
                        var input = js.Deserialize<Url_Input>(jr);
                        input_string = new StringBuilder().Append(input.Parm1).Append(input.Op).Append(input.Parm2).ToString();
                        Console.WriteLine($"Retrieved input: {input_string}");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Failed to parse input from provided url: {exception.Message}, {exception.ToString()}");
                throw new Exception(exception.Message, exception);
            }
            return input_string;
        }

        /// <summary>
        /// Check for a Term then handle '+' or '-'
        /// </summary>
        /// <returns></returns>
        public double Expression()
        {
            try
            {
                var left = Term(); // read and evaluate a term. On first call we'd expect it to return a numeric or a bracket.
                var t = ts.Get();

                while (true)
                {
                    switch (t._kind)
                    {
                        case '+':
                            left += Term();
                            Console.WriteLine($"Left = {left}");
                            t = ts.Get();   // Get the next character for evaluation in the next loop
                            break;

                        case '-':
                            left -= Term();
                            t = ts.Get(); // Get the next character for evaluation in the next loop
                            break;

                        default:
                            ts.Putback(t);  // The token isn't a + or a -, put it back for future evaluation.
                            return left;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to calculate a result:{e.Message}");
            }
        }

        /// <summary>
        /// Check for a Primary then handle '*', '/'
        /// </summary>
        /// <returns></returns>
        public double Term()
        {
            var left = Primary();
            var t = ts.Get();

            while (true)
            {
                switch (t._kind)
                {
                    case '*':
                        left *= Primary();
                        t = ts.Get();
                        break;

                    case '/':
                        {
                            var d = Primary();
                            if (d.Equals(0)) throw new InvalidOperationException();
                            left /= d;
                            t = ts.Get();
                            break;
                        }

                    default:
                        ts.Putback(t);
                        return left;
                }
            }
        }

        /// <summary>
        /// Handles numbers and brackets
        /// </summary>
        /// <returns></returns>
        public double Primary()
        {
            var t = ts.Get();

            switch (t._kind)
            {
                case '(':
                    {
                        // Compute the contents of the bracket before continuing.
                        var d = Expression();
                        t = ts.Get();
                        if (t._kind != ')') throw new FormatException();
                        return d;
                    }
                case 'n':
                    return t._value;
                case '-':
                    return -Primary();
                case '+':
                    return Primary();
                default:
                    throw new Exception("No primary found");
            }
        }
    }
}
