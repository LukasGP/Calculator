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
        }
    }
}
