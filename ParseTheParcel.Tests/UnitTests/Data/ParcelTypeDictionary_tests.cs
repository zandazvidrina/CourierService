using NUnit.Framework;
using ParseTheParcel.Data.Services;

namespace ParseTheParcel.Tests.UnitTests.Data
{
    [TestFixture]
    class ParcelTypeDictionary_tests
    {
        [Test]
        public void Check3SizesAreReturned()
        {
            //Arrange
            var sut = new ParcelTypeDictionary();
            
            //Act, Assert
            Assert.That(sut.GetAll().Count, Is.EqualTo(3));
        }
    }
}
