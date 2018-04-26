using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private const string _commandurl = "http://test.ethorstat.com/test.ashx";

        public Calculator()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                var calc = new Calculator_Core();
                var result = calc.CalculateFromUrl(_commandurl);
                WriteCalculationDetails(result.Item1, result.Item2.ToString());
            }
            catch(Exception exception)
            {
                WriteCalculationDetails($"Unable to run calculation from url:{exception.Message}", "");
            }
        }

        private void Challenge_Start_Click(object sender, EventArgs e)
        {
            try
            {
                var input = challenge_input.Text;
                Console.WriteLine($"Received input: {input}");
                var calc = new Calculator_Core();
                var result = calc.CalculateFromString(input);
                WriteCalculationDetails(result.Item1, result.Item2.ToString());
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message, exception);
                WriteCalculationDetails("Unable to run calculation, please double check that your input is correct", "");
            }
        }

        private void WriteCalculationDetails(string input, string result)
        {
            var lvi = new ListViewItem(input);
            lvi.SubItems.Add(result);
            calculatorDisplay.Items.Add(lvi);
        }
    }
}
