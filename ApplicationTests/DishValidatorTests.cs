using Application.Constraints;
using Application.Models;
using Application.Validators;
using NUnit.Framework;
using System.Linq;

namespace ApplicationTests
{
    [TestFixture]
    public class DishValidatorTests
    {
        private DishValidator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DishValidator();
        }

        [Test]
        public void ValidateSucceedsWhenConstraintsAreNull()
        {
            var dish = new Dish
            {
                Name = DishName.Coffee,
                Count = 10,
                Constraints = null
            };

            var actual = _sut.Validate(dish);

            Assert.IsTrue(actual.IsValid);
        }

        [Test]
        public void ValidateSucceedsWhenMaxCountAllowedIsNull()
        {
            var dish = new Dish
            {
                Name = DishName.Potato,
                Count = 10,
                Constraints = new DishConstraints { MaxCountAllowed = null }
            };

            var actual = _sut.Validate(dish);

            Assert.IsTrue(actual.IsValid);
        }

        [Test]
        public void ValidateSucceedsWhenCountIsEqualToMaxCountAllowed()
        {
            var dish = new Dish
            {
                Name = DishName.Steak,
                Count = 1,
                Constraints = new DishConstraints { MaxCountAllowed = 1 }
            };

            var actual = _sut.Validate(dish);

            Assert.IsTrue(actual.IsValid);
        }

        [Test]
        public void ValidateFailsWhenCountExceedsMaxCountAllowed()
        {
            var dish = new Dish
            {
                Name = DishName.Steak,
                Count = 2,
                Constraints = new DishConstraints { MaxCountAllowed = 1 }
            };

            var actual = _sut.Validate(dish);

            Assert.IsFalse(actual.IsValid);
            Assert.AreEqual("Count for 'Steak' must be less than or equal to 1.", actual.Errors.Single().ErrorMessage);
        }
    }
}
