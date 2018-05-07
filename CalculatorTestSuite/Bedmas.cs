using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTestSuite
{
    [TestClass]
    public class Bedmas
    {
        [TestMethod]
        public void MultiplicationAndAddition()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "-3+4*-5+2";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input,-21);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void DivisionAndAddition()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "-3+20/-5";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -7);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void Brackets()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "(5+20)/5";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 5);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MassOrderOfOperations()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "3+4*(5+20)/5*2";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input,43);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }
    }
}
