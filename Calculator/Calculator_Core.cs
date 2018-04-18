using Calculator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

public class Calculator_Core
{
    private const string _commandurl = "http://test.ethorstat.com/test.ashx";
    Token_stream ts;
    public Calculator_Core() {}

    /// <summary>
    /// Get the input for the stored command url and run calculate to determine the result.
    /// </summary>
    /// <returns>
    /// Tuple<string,double>
    ///    -- Item1 is the input text
    ///    -- Item2 is the calculated result
    /// </returns>
    /// </returns>
    public Tuple<string,double> CalculateFromUrl()
    {
        var input = InputFromUrl(_commandurl);
        return Calculate(input);
    }

    /// <summary>
    /// From the given input calculate the result..
    /// </summary>
    /// <param name="input"></param>
    /// <returns>
    /// Tuple<string,double>
    ///    -- Item1 is the input text
    ///    -- Item2 is the calculated result
    /// </returns>
    public Tuple<string,double> Calculate(string input)
    {
        try
        {
            ts = new Token_stream(input);
            while (ts._input.Length != 0)
            {
                var t = ts.Get();
                while (t._kind == 'p') t = ts.Get();     // get through all prints
                if (t._kind == 'q') return null;    // quit
                ts.Putback(t);
                var result = Expression();
                Console.WriteLine($"result is: {result}");
                return new Tuple<string,double>(input,result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message, e);
        }
        return null;
    }

    /// <summary>
    /// Get our input from the designated url and turn into a format consumable by our calculator.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private string InputFromUrl(string url)
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
                    Console.WriteLine($"{input.Parm1},{input.Parm2},{input.Op}");
                    input_string = new StringBuilder().Append(input.Parm1).Append(input.Op).Append(input.Parm2).ToString();
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Failed to parse input from provided url: {exception.Message}, {exception.ToString()}");
        }
        return input_string;
    }

    /// <summary>
    /// Handle '+' or '-'
    /// </summary>
    /// <returns></returns>
    private double Expression()
    {
        var left = Term(); // read and evaluate a term.
        var t = ts.Get();

        while (true)
        {
            switch (t._kind)
            {
                // TODO: Are the additional Gets necessary, or will we end up skipping characters.
                case '+':
                    left += Term();
                    Console.WriteLine($"Left = {left}");
                    t = ts.Get();
                    break;

                case '-':
                    left -= Term();
                    t = ts.Get();
                    break;

                    default:
                        ts.Putback(t);  // The token isn't a + or a -, put it back for future evaluation.
                        return left;
            }
        }
    }

    /// <summary>
    /// Handle '*', '/', and '%'
    /// </summary>
    /// <returns></returns>
    private double Term()
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
    private double Primary()
    {
        var t = ts.Get();

        switch (t._kind)
        {
            case '(':
                {
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
