using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTestSuite
{
    [TestClass]
    public class Primary
    {
        [TestMethod]
        public void NumericalPrimary()
        {
            // SETUP
            var input = "25";
            double expectedResult = 25;
            var calc = new Calculator_Core();
            calc.SetInput(input);

            // EXECUTE
            var numericPrimary = calc.Primary();

            // ASSERT
            Assert.AreEqual(expectedResult, numericPrimary);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void BracketWithNoClosingPrimary()
        {
            // SETUP
            var input = "(";
            var expectedResult = new FormatException();
            var calc = new Calculator_Core();
            calc.SetInput(input);

            // EXECUTE
            calc.Primary();
        }
    }
}
