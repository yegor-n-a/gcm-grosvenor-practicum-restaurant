using Application;
using Application.Sorters;
using Application.Validators;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationTests
{
    [TestFixture]
    public class DishManagerTests
    {
        private DishManager _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DishManager(
                new DishValidator(),
                new DishSorter()
            );
        }

        [Test]
        public void EmptyListReturnsEmptyList()
        {
            var order = new Order();
            var actual = _sut.GetDishes(order);
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void ListWith1ReturnsOneSteak()
        {
            var order = new Order
            {
                Dishes = new List<int>
                {
                    1
                }
            };

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("steak", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }
    }
}
