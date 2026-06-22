using NUnit.Framework;
using Moq;
using ConverterLib;
using CurrencyConverterApp;

namespace ConverterLib.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private Mock<IDollarToEuroExchangeRateFeed> _mockFeed;
        private Converter _converter;

        [SetUp]
        public void SetUp()
        {
            _mockFeed = new Mock<IDollarToEuroExchangeRateFeed>();
            _converter = new Converter(_mockFeed.Object);
        }

        // Test CelsiusToKelvin
        [Test]
        public void CelsiusToKelvin_ValidCelsius_ReturnsKelvin()
        {
            double result = _converter.CelsiusToKelvin(25.0);
            Assert.That(result, Is.EqualTo(298.15));
        }

        // Test KilogramToPound
        [Test]
        public void KilogramToPound_ValidKilogram_ReturnsPound()
        {
            double result = _converter.KilogramToPound(10.0);
            Assert.That(result, Is.EqualTo(22.05));
        }

        // Test KilometerToMile
        [Test]
        public void KilometerToMile_ValidKilometer_ReturnsMile()
        {
            double result = _converter.KilometerToMile(16.09);
            Assert.That(result, Is.EqualTo(10.0));
        }

        // Test LiterToGallon
        [Test]
        public void LiterToGallon_ValidLiter_ReturnsGallon()
        {
            double result = _converter.LiterToGallon(37.85);
            Assert.That(result, Is.EqualTo(10.0));
        }

        // Test USDToEuro using mock feed
        [Test]
        public void USDToEuro_ValidDollarAmount_ReturnsConvertedEuro()
        {
            // Setup the mock exchange rate to return 0.92
            _mockFeed.Setup(feed => feed.GetActualUSDollarValue()).Returns(0.92);

            double result = _converter.USDToEuro(100.0);
            Assert.That(result, Is.EqualTo(92.0));
        }
    }
}
