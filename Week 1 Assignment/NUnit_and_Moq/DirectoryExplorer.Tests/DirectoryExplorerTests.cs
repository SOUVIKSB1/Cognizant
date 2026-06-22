using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _mockExplorer;
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            _mockExplorer = new Mock<IDirectoryExplorer>();
            
            // Set up mock to return the hardcoded list of file names
            var filesList = new List<string> { _file1, _file2 };
            _mockExplorer.Setup(exp => exp.GetFiles(It.IsAny<string>())).Returns(filesList);
        }

        [TestCase("C:\\DummyPath")]
        public void GetFiles_MockExplorer_ReturnsExpectedFiles(string path)
        {
            ICollection<string> files = _mockExplorer.Object.GetFiles(path);

            // Assertions as requested in instructions
            Assert.That(files, Is.Not.Null);
            Assert.That(files.Count, Is.EqualTo(2));
            Assert.That(files, Contains.Item(_file1));
        }
    }
}
