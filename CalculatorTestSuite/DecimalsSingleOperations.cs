using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTestSuite
{
    [TestClass]
    public class DecimalsSingleOperations
    {
        [TestMethod]
        public void SingleAdditionPositiveResult()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "-3.5+4.5";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input,1);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleAdditionNegativeResult()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "-8+3";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -5);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AdditionOfTwoNegativeValues()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "-8+-3";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -11);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleSubtractionPositiveResult()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "8-3";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 5);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleSubtractionNegativeResult()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "5-8";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -3);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        // TODO: Test lower and upper bounds

        [TestMethod]
        public void SingleMultiplicationPositives()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "5*8";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 40);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleMultiplicationNegatives()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "-5*-8";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 40);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleMultiplicationOneNegative()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "5*-8";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -40);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleDivisionPositives()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "40/8";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 5);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleDivisionNegatives()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "-40/-8";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 5);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SingleDivisionOneNegatives()
        {
            // SETUP
            var calc = new Calculator_Core();
            var input = "40/-8";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -5);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }
    }
}
