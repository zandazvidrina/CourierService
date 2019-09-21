using NUnit.Framework;
using ParseTheParcel.Business.Logic;
using ParseTheParcel.Business.Models;
using ParseTheParcel.Data.Services;

namespace ParseTheParcel.Tests.UnitTests.Business
{
    [TestFixture()]
    class ParcelValidation_tests
    {

        [Test]
        [TestCase(25, true)]
        [TestCase(26, false)]   //value that exceeds max
        [TestCase(1, true)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        public void ValidateParcelWeight(int weight, bool expected)
        {
            //Arrange
            var model = new Parcel()
            {
                Weight = weight
            };

            var sut = new ParcelValidation(new ParcelTypeDictionary(), new ParcelConfiguration());

            //Act, Assert
            Assert.That(sut.ValidateWeight(model), Is.EqualTo(expected));
        }


        [Test]
        [TestCase(400, true)]
        [TestCase(401, false)]      //value that exceeds max
        [TestCase(1, true)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        public void ValidateParcelLength(int length, bool expected)
        {
            //Arrange
            var model = new Parcel()
            {
                Length = length
            };

            var sut = new ParcelValidation(new ParcelTypeDictionary(), new ParcelConfiguration());

            //Act, Assert
            Assert.That(sut.ValidateLength(model), Is.EqualTo(expected));
        }


        [Test]
        [TestCase(600, true)]
        [TestCase(601, false)]      //value that exceeds max
        [TestCase(1, true)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        public void ValidateParcelBreadth(int breadth, bool expected)
        {
            //Arrange
            var model = new Parcel()
            {
                Breadth = breadth
            };

            var sut = new ParcelValidation(new ParcelTypeDictionary(), new ParcelConfiguration());

            //Act, Assert
            Assert.That(sut.ValidateBreadth(model), Is.EqualTo(expected));
        }


        [Test]
        [TestCase(250, true)]
        [TestCase(251, false)]      //value that exceeds max
        [TestCase(1, true)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        public void ValidateParcelHeight(int height, bool expected)
        {
            //Arrange
            var model = new Parcel()
            {
                Height = height
            };

            var sut = new ParcelValidation(new ParcelTypeDictionary(), new ParcelConfiguration());

            //Act, Assert
            Assert.That(sut.ValidateHeight(model), Is.EqualTo(expected));
        }

    }
}
