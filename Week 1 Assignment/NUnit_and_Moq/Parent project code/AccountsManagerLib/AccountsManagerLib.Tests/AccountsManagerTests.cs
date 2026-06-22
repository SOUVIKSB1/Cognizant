using NUnit.Framework;
using AccountsManagerLib;

namespace AccountsManagerLib.Tests
{
    [TestFixture]
    public class AccountsManagerTests
    {
        private AccountsManager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = new AccountsManager();
        }

        // Test valid login user_11
        [Test]
        public void ValidateUser_ValidUser11_ReturnsWelcomeMessage()
        {
            string result = _manager.ValidateUser("user_11", "secret@user11");
            Assert.That(result, Is.EqualTo("Welcome user_11!!!"));
        }

        // Test valid login user_22
        [Test]
        public void ValidateUser_ValidUser22_ReturnsWelcomeMessage()
        {
            string result = _manager.ValidateUser("user_22", "secret@user22");
            Assert.That(result, Is.EqualTo("Welcome user_22!!!"));
        }

        // Test invalid login
        [Test]
        public void ValidateUser_InvalidCredentials_ReturnsInvalidMessage()
        {
            string result = _manager.ValidateUser("user_11", "wrong_password");
            Assert.That(result, Is.EqualTo("Invalid user id/password"));
        }

        // Test missing user ID throws ArgumentException
        [Test]
        public void ValidateUser_EmptyUserId_ThrowsArgumentException()
        {
            Assert.That(() => _manager.ValidateUser("", "secret@user11"),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Both user id and password are mandatory"));
        }

        // Test missing password throws ArgumentException
        [Test]
        public void ValidateUser_NullPassword_ThrowsArgumentException()
        {
            Assert.That(() => _manager.ValidateUser("user_11", null!),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Both user id and password are mandatory"));
        }
    }
}
