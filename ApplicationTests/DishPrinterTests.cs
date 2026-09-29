using Application.Models;
using Application.Printers;
using NUnit.Framework;
using System.Collections.Generic;

namespace ApplicationTests
{
    [TestFixture]
    public class DishPrinterTests
    {
        private DishPrinter _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DishPrinter();
        }

        [Test]
        public void PrintDoesNotAddCountSuffixForSingleDish()
        {
            var dishes = new[]
            {
                new Dish { Name = DishName.Steak, Count = 1 }
            };

            var actual = _sut.Print(dishes);

            Assert.AreEqual("steak", actual);
        }

        [Test]
        public void PrintAddsCountSuffixForMultipleDishes()
        {
            var dishes = new[]
            {
                new Dish { Name = DishName.Potato, Count = 2 }
            };

            var actual = _sut.Print(dishes);

            Assert.AreEqual("potato(x2)", actual);
        }

        [Test]
        public void PrintJoinsMultipleDishesWithCommasInProvidedOrder()
        {
            var dishes = new[]
            {
                new Dish { Name = DishName.Steak, Count = 1 },
                new Dish { Name = DishName.Potato, Count = 2 },
                new Dish { Name = DishName.Cake, Count = 1 }
            };

            var actual = _sut.Print(dishes);

            Assert.AreEqual("steak,potato(x2),cake", actual);
        }

        [Test]
        public void PrintReturnsEmptyStringForEmptyCollection()
        {
            var actual = _sut.Print(new List<Dish>());

            Assert.AreEqual(string.Empty, actual);
        }
    }
}
