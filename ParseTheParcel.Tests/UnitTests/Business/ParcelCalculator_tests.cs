using NUnit.Framework;
using ParseTheParcel.Business.Logic;
using ParseTheParcel.Business.Models;
using ParseTheParcel.Data.Services;

namespace ParseTheParcel.Tests.UnitTests
{
    [TestFixture]
    class ParcelCalculator_tests
    {
        [Test]
        [TestCase(1, 1, 1, 5)]
        [TestCase(200,300,150,5)]
        [TestCase(201, 300, 150, 7.5)]
        [TestCase(300,400,200,7.5)]
        [TestCase(300, 401, 200, 8.5)]
        [TestCase(400,600,250,8.5)]
        [TestCase(400, 600, 250, 8.5)]
        [TestCase(400, 600, 250, 8.5)]
        [TestCase(200, 300, 250, 8.5)]  //1 of the values exceeds the smaller size
        [TestCase(305, 555, 190, 8.5)]  //1 of the values exceeds the medium size
        [TestCase(255, 300, 150, 7.5)]  //1 of the values exceeds the smaller size and is in medium
        public void IsPriceCalculatedCorrectly(int length, int breadth, int height, double exp)
        {
            //Arrange
            var model = new Parcel()
            {
                Length = length,
                Breadth = breadth,
                Height = height
            };
            var sut = new ParcelCalculator(new ParcelTypeDictionary());

            //Act
            var finalModel=sut.CalculatePrice(model);

            //Assert
            Assert.That(finalModel.Price, Is.EqualTo(exp));
            
        }

        [Test]
        [TestCase(300,150,200,150,200,300)]
        [TestCase(250, 250, 100, 100, 250, 250)]
        [TestCase(150, 350, 350, 150, 350, 350)]
        public void IsParcelRotatedCorrectly(int initialLength, int initialBreadth, int initialHeight, int expectedLength, int expectedBreadth, int expectedHeight)
        {
            //Arrange
            var model = new Parcel()
            {
                Length = initialLength,
                Breadth = initialBreadth,
                Height = initialHeight
            };
            var sut = new ParcelCalculator(new ParcelTypeDictionary());

            //Act
            var finalModel = sut.RotateParcelIfNeeded(model);

            //Assert
            Assert.That(finalModel.Height, Is.EqualTo(expectedLength));
            Assert.That(finalModel.Length, Is.EqualTo(expectedBreadth));
            Assert.That(finalModel.Breadth, Is.EqualTo(expectedHeight));
            
        }
        [Test]
        public void ParcelIsNotRotated()
        {
            //Arrange
            var model = new Parcel()
            {
                Length = 300,
                Breadth = 400,
                Height = 200
            };
            var sut = new ParcelCalculator(new ParcelTypeDictionary());

            //Act
            sut.RotateParcelIfNeeded(model);

            //Assert
            Assert.That(model.Height, Is.EqualTo(200));
            Assert.That(model.Length, Is.EqualTo(300));
            Assert.That(model.Breadth, Is.EqualTo(400));

        }
    }
}
