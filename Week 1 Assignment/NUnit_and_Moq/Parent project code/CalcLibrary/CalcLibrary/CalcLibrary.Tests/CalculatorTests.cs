using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        // Exercise 1: Test Addition with Parameterized Test Cases
        [TestCase(10, 20, 30)]
        [TestCase(-5, -5, -10)]
        [TestCase(1.5, 2.5, 4.0)]
        public void Addition_Scenario_ReturnsSum(double a, double b, double expected)
        {
            double actual = _calculator.Addition(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        // Exercise 2: Test Subtraction
        [TestCase(20, 10, 10)]
        [TestCase(-5, -5, 0)]
        [TestCase(5.5, 2.5, 3.0)]
        public void Subtraction_Scenario_ReturnsDifference(double a, double b, double expected)
        {
            double actual = _calculator.Subtraction(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        // Exercise 2: Test Multiplication
        [TestCase(10, 20, 200)]
        [TestCase(-5, -5, 25)]
        [TestCase(1.5, 2.0, 3.0)]
        public void Multiplication_Scenario_ReturnsProduct(double a, double b, double expected)
        {
            double actual = _calculator.Multiplication(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        // Exercise 2: Test Division (including division by zero exception test)
        [TestCase(20, 10, 2)]
        [TestCase(1.5, 0.5, 3)]
        [TestCase(10, 0, 0)] // Divisor is 0, expected value doesn't matter since it throws
        public void Division_Scenario_ReturnsQuotientOrThrows(double a, double b, double expected)
        {
            try
            {
                double actual = _calculator.Division(a, b);
                if (b == 0)
                {
                    Assert.Fail("Division by zero");
                }
                else
                {
                    Assert.That(actual, Is.EqualTo(expected));
                }
            }
            catch (ArgumentException ex)
            {
                Assert.That(b, Is.EqualTo(0));
                Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
            }
        }

        // Exercise 2 (Void methods): Test Add and Clear
        [Test]
        public void TestAddAndClear_Scenario_ClearsResult()
        {
            double sum = _calculator.Addition(100, 200);
            Assert.AreEqual(300, sum);
            Assert.AreEqual(300, _calculator.GetResult);

            _calculator.AllClear();
            Assert.AreEqual(0, _calculator.GetResult);
        }
    }
}
