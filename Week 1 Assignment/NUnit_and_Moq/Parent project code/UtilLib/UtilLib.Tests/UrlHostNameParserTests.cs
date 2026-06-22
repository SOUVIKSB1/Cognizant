using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new UrlHostNameParser();
        }

        // Test success path: HTTP URL
        [Test]
        public void ParseHostName_HttpUrl_ReturnsHostName()
        {
            string hostName = _parser.ParseHostName("http://www.google.com/search");
            Assert.That(hostName, Is.EqualTo("www.google.com"));
        }

        // Test success path: HTTPS URL
        [Test]
        public void ParseHostName_HttpsUrl_ReturnsHostName()
        {
            string hostName = _parser.ParseHostName("https://github.com/microsoft/dotnet");
            Assert.That(hostName, Is.EqualTo("github.com"));
        }

        // Test failure path: Invalid protocol
        [Test]
        public void ParseHostName_InvalidProtocolUrl_ThrowsFormatException()
        {
            Assert.That(() => _parser.ParseHostName("ftp://ftp.example.com/files"),
                Throws.TypeOf<FormatException>().With.Message.EqualTo("Url is not in correct format"));
        }
    }
}
