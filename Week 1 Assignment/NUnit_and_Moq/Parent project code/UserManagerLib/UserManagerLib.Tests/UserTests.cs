using NUnit.Framework;
using System;
using UserManagerLib;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new User();
        }

        // Test happy path: valid PAN card number (10 characters)
        [Test]
        public void CreateUser_ValidPanCard_SuccessfullyValidates()
        {
            _user.PANCardNo = "ABCDE1234F";
            Assert.That(() => _user.CreateUser(_user), Throws.Nothing);
        }

        // Test exception path: null PAN card throws NullReferenceException
        [Test]
        public void CreateUser_NullPanCard_ThrowsNullReferenceException()
        {
            _user.PANCardNo = null!;
            Assert.That(() => _user.CreateUser(_user),
                Throws.TypeOf<NullReferenceException>().With.Message.EqualTo("Invalid Pan Card Number"));
        }

        // Test exception path: empty PAN card throws NullReferenceException
        [Test]
        public void CreateUser_EmptyPanCard_ThrowsNullReferenceException()
        {
            _user.PANCardNo = "";
            Assert.That(() => _user.CreateUser(_user),
                Throws.TypeOf<NullReferenceException>().With.Message.EqualTo("Invalid Pan Card Number"));
        }

        // Test exception path: PAN card less than 10 chars throws FormatException
        [Test]
        public void CreateUser_ShortPanCard_ThrowsFormatException()
        {
            _user.PANCardNo = "ABC123F";
            Assert.That(() => _user.CreateUser(_user),
                Throws.TypeOf<FormatException>().With.Message.EqualTo("Pan Card Number Should contain only 10 characters"));
        }

        // Test exception path: PAN card greater than 10 chars throws FormatException
        [Test]
        public void CreateUser_LongPanCard_ThrowsFormatException()
        {
            _user.PANCardNo = "ABCDE12345FG";
            Assert.That(() => _user.CreateUser(_user),
                Throws.TypeOf<FormatException>().With.Message.EqualTo("Pan Card Number Should contain only 10 characters"));
        }
    }
}
