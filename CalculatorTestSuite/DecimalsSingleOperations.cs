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
            var input = "-8.5+3.5";
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
            var input = "-8.5+-3.5";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -12);

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
            var input = "8.5-3.5";
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
            var input = "5.5-8.5";
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
            var input = "0.25*4";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 1);

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
            var input = "-0.25*-4";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 1);

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
            var input = "0.25*-4";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -1);

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
            var input = "0.5/0.25";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 2);

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
            var input = "-0.5/-0.25";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, 2);

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
            var input = "0.5/-0.25";
            Tuple<string, double> expectedResult = new Tuple<string, double>(input, -2);

            // EXECUTE
            var result = calc.CalculateFromString(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }
    }
}
