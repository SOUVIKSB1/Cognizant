using NUnit.Framework;
using System.Collections;
using SeasonsLib;

namespace FourSeasonsLib.Tests
{
    [TestFixture]
    public class SeasonTellerTests
    {
        private SeasonTeller _teller;

        [SetUp]
        public void SetUp()
        {
            _teller = new SeasonTeller();
        }

        // --- Way 1: Straightforward method-based TestCaseSource ---
        private static IEnumerable GetSeasonTestData()
        {
            yield return new TestCaseData("February", "Spring");
            yield return new TestCaseData("March", "Spring");
            yield return new TestCaseData("April", "Summer");
            yield return new TestCaseData("May", "Summer");
            yield return new TestCaseData("June", "Summer");
            yield return new TestCaseData("July", "Monsoon");
            yield return new TestCaseData("August", "Monsoon");
            yield return new TestCaseData("September", "Monsoon");
            yield return new TestCaseData("October", "Autumn");
            yield return new TestCaseData("November", "Autumn");
            yield return new TestCaseData("December", "Winter");
            yield return new TestCaseData("January", "Winter");
            yield return new TestCaseData("InvalidMonth", "Invalid Season");
        }

        [Test]
        [TestCaseSource(nameof(GetSeasonTestData))]
        public void DisplaySeasonBy_VariousMonths_ReturnsExpectedSeason(string month, string expectedSeason)
        {
            string actualSeason = _teller.DisplaySeasonBy(month);
            Assert.That(actualSeason, Is.EqualTo(expectedSeason));
        }

        // --- Way 2: Alternate Class-based TestCaseSource ---
        [Test]
        [TestCaseSource(typeof(ExternalSeasonTestData), nameof(ExternalSeasonTestData.TestCases))]
        public void DisplaySeasonBy_ExternalSource_ReturnsExpectedSeason(string month, string expectedSeason)
        {
            string actualSeason = _teller.DisplaySeasonBy(month);
            Assert.That(actualSeason, Is.EqualTo(expectedSeason));
        }
    }

    // Separate class for test cases to demonstrate alternative approach
    public class ExternalSeasonTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("FEBRUARY", "Spring");
                yield return new TestCaseData("june", "Summer");
                yield return new TestCaseData("AUGUST", "Monsoon");
                yield return new TestCaseData("november", "Autumn");
                yield return new TestCaseData("JANUARY", "Winter");
                yield return new TestCaseData("xyz", "Invalid Season");
            }
        }
    }
}
