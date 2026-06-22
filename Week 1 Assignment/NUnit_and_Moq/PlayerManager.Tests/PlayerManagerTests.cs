using NUnit.Framework;
using Moq;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> _mockMapper;

        [OneTimeSetUp]
        public void Init()
        {
            _mockMapper = new Mock<IPlayerMapper>();
        }

        // Test happy path: Register a new player
        [TestCase("Sachin")]
        public void RegisterNewPlayer_ValidPlayer_ReturnsRegisteredPlayer(string name)
        {
            // Setup mock to return false (player does not exist in DB)
            _mockMapper.Setup(mapper => mapper.IsPlayerNameExistsInDb(name)).Returns(false);
            _mockMapper.Setup(mapper => mapper.AddNewPlayerIntoDb(name)).Verifiable();

            Player player = Player.RegisterNewPlayer(name, _mockMapper.Object);

            // Assertions as requested in instructions (assert various player attributes)
            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo(name));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));

            // Verify mapping DB insertion was called once
            _mockMapper.Verify(mapper => mapper.AddNewPlayerIntoDb(name), Times.Once);
        }

        // Test exception path: Player name empty throws ArgumentException
        [TestCase("")]
        [TestCase("   ")]
        public void RegisterNewPlayer_EmptyName_ThrowsArgumentException(string name)
        {
            // Modern NUnit replacement for legacy ExpectedException attribute
            Assert.That(() => Player.RegisterNewPlayer(name, _mockMapper.Object),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Player name can't be empty."));
        }

        // Test exception path: Duplicate player name throws ArgumentException
        [TestCase("Dhoni")]
        public void RegisterNewPlayer_DuplicateName_ThrowsArgumentException(string name)
        {
            // Setup mock to return true (player exists in DB)
            _mockMapper.Setup(mapper => mapper.IsPlayerNameExistsInDb(name)).Returns(true);

            // Modern NUnit replacement for legacy ExpectedException attribute
            Assert.That(() => Player.RegisterNewPlayer(name, _mockMapper.Object),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Player name already exists."));
        }
    }
}
