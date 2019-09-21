using NUnit.Framework;
using ParseTheParcel.Data.Services;

namespace ParseTheParcel.Tests.UnitTests
{
    [TestFixture]
    class ParcelConfiguration_tests
    {
        [Test]
        public void ReturnCorrectMaxWeight()
        {
            //Arrange
            var sut = new ParcelConfiguration();

            //Act, Assert
            Assert.That(sut.GetMaxWeight(), Is.EqualTo(25));
        }

      
    }
}
