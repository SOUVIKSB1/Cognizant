using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    [TestFixture]
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new LeapYearCalculator();
        }

        // Test leap years
        [TestCase(2000, 1)]
        [TestCase(2024, 1)]
        [TestCase(2028, 1)]
        [TestCase(1996, 1)]
        public void IsLeapYear_LeapYears_ReturnsOne(int year, int expected)
        {
            int result = _calculator.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Test non-leap years
        [TestCase(1900, 0)]
        [TestCase(2100, 0)]
        [TestCase(2023, 0)]
        [TestCase(1800, 0)]
        public void IsLeapYear_NonLeapYears_ReturnsZero(int year, int expected)
        {
            int result = _calculator.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Test invalid years (out of boundaries 1753-9999)
        [TestCase(1500, -1)]
        [TestCase(1752, -1)]
        [TestCase(10000, -1)]
        [TestCase(0, -1)]
        [TestCase(-100, -1)]
        [TestCase(1753, 0)] // boundary check - valid non-leap
        [TestCase(9999, 0)] // boundary check - valid non-leap
        public void IsLeapYear_BoundaryAndInvalidYears_ReturnsExpectedCode(int year, int expected)
        {
            int result = _calculator.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
