using Calculator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

public class Calculator_Core
{
    string _commandurl = "http://test.ethorstat.com/test.ashx";

    public Calculator_Core()
    {
    }

    public float Calculate()
    {
        var input = InputFromUrl(_commandurl);
        return 0.00F;
    }

    public float Calculate(string input)
    {
        // TODO
        return 0.00F;
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
}

public class Token
{
    char Kind { get; set; }
    string Name { get; set; }
    double Value { get; set; }

    public Token(char ch) { }
    public Token(char ch, double val) { }
    public Token(char ch, string n) { }
}

public interface IToken_stream
{
    Token Get();
    void Putback(Token t);
    void Ignore(char c);
}

public class Token_stream:IToken_stream
{
    private bool _full;
    private Token _buffer;
    private string _input;

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
    }

    public Token Get()
    {
        if (_full)
        {
            _full = false;
            return _buffer;
        }

        if (_input.Equals(null))
        {
            throw new Exception("Unable to process empty input.");
        }

        Evaluate_Input(_input);
    }

    private Token Evaluate_Input(string input)
    {
        for (int i=0; i<input.Length; i++)
        {
            var ch = input[i];
            if (ch >= 0 && ch <= 9)
            {

                var whole_number = new List<string>();
                // TODO: Handle numeric input
            }
            else
            {
                // TODO: Handle text input
                switch (ch)
                {
                    case 'q':

                    default: break;
                }
            }
            Token t = new Token(ch);
        }
    }

    public void Putback(Token t)
    {
        if (_full)
            throw new Exception("Attempted to put item back into a full buffer.");
        _buffer = t;
        _full = true;
    }

    public void Ignore(char ch)
    {
        // TODO:
    }
}
