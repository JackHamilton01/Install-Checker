using InstallChecker.Services;
using Moq;
using NUnit.Framework;

namespace Unit_Tests
{
    [TestFixture]
    public class Tests
    {
        IFileService fileService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string file = @"C:\schematic.png";
            var mock = new Mock<IFileService>();

            var result = mock.Setup(x => x.CheckIfFileExists(file)).Returns(true);

            Assert.That(result, Is.True);

            var controller = new 
        }
    }
}