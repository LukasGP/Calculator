using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var calc = new Calculator_Core();
            var result = calc.CalculateFromUrl();
            WriteCalculationDetails(result.Keys.ToString(), result.Values.ToString());
        }

        private void challenge_start_Click(object sender, EventArgs e)
        {
            var input = challenge_input.Text;
            Console.WriteLine($"Received input: {input}");
            var calc = new Calculator_Core();
            var result = calc.Calculate(input);
            WriteCalculationDetails(input, result.ToString());
        }

        private void WriteCalculationDetails(string input, string result)
        {
            var lvi = new ListViewItem(input);
            lvi.SubItems.Add(result);
            calculatorDisplay.Items.Add(lvi);
        }
    }
}
