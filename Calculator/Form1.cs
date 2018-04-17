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
            calc.Calculate();
        }

        private void challenge_start_Click(object sender, EventArgs e)
        {
            var input = challenge_input.Text;
            Console.WriteLine($"Received input: {input}");
            var calc = new Calculator_Core();
            calc.Calculate(input);
        }
    }
}
