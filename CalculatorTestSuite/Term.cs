using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTestSuite
{
    /// <summary>
    /// Summary description for Term
    /// </summary>
    [TestClass]
    public class Term
    {
        [TestMethod]
        public void MultiplicationThenAddition()
        {
            // SETUP
            var input = "4*5+25";
            double expectedResult = 20;
            var calc = new Calculator_Core();
            calc.SetInput(input);

            // EXECUTE
            var termResult = calc.Term();

            // ASSERT
            Assert.AreEqual(expectedResult, termResult);
        }

        [TestMethod]
        public void DivisionThenAddition()
        {
            // SETUP
            var input = "20/5+25";
            double expectedResult = 4;
            var calc = new Calculator_Core();
            calc.SetInput(input);

            // EXECUTE
            var termResult = calc.Term();

            // ASSERT
            Assert.AreEqual(expectedResult, termResult);
        }
    }
}
