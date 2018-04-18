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
            var calc = new Calculator_Core();
            var result = calc.CalculateFromUrl(_commandurl);
            WriteCalculationDetails(result.Item1, result.Item2.ToString());
        }

        private void challenge_start_Click(object sender, EventArgs e)
        {
            var input = challenge_input.Text;
            Console.WriteLine($"Received input: {input}");
            var calc = new Calculator_Core();
            var result = calc.Calculate(input);
            WriteCalculationDetails(result.Item1, result.Item2.ToString());
        }

        private void WriteCalculationDetails(string input, string result)
        {
            var lvi = new ListViewItem(input);
            lvi.SubItems.Add(result);
            calculatorDisplay.Items.Add(lvi);
        }
    }
}
