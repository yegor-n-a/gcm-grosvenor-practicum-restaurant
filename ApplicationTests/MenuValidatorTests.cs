using Application.Models;
using Application.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationTests
{
    [TestFixture]
    public class MenuValidatorTests
    {
        private MenuValidator _sut;
        private Menu _menu;

        [SetUp]
        public void Setup()
        {
            _sut = new MenuValidator();
            _menu = new Menu(new Dictionary<int, DishName>
            {
                { 1, DishName.Steak },
                { 2, DishName.Potato },
                { 3, DishName.Wine }
            });
        }

        [Test]
        public void ValidateReturnsValidResultsForKnownItemIds()
        {
            var actual = _sut.Validate(_menu, new[] { 1, 2, 3 });

            Assert.IsTrue(actual.Values.All(item => item.IsValid));
        }

        [Test]
        public void ValidateReturnsErrorForUnknownItemId()
        {
            var actual = _sut.Validate(_menu, new[] { 1, 9 });

            Assert.IsTrue(actual[1].IsValid);
            Assert.IsFalse(actual[9].IsValid);
            Assert.AreEqual("Dish # 9 is not available for order.", actual[9].Errors.Single());
        }

        [Test]
        public void ValidateAllowsDuplicateKnownItemIds()
        {
            var actual = _sut.Validate(_menu, new[] { 2, 2 });

            Assert.IsTrue(actual[2].IsValid);
        }

        [Test]
        public void ValidateThrowsWhenMenuIsNull()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Validate(null, new[] { 1 }));
        }

        [Test]
        public void ValidateThrowsWhenOrderedItemsAreEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Validate(_menu, Enumerable.Empty<int>()));
        }
    }
}
