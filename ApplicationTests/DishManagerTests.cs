using Application;
using Application.Models;
using Application.Sorters;
using Application.Validators;
using NUnit.Framework;
using System;
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
        public void EmptyListThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Order<Dish>(Enumerable.Empty<Dish>()));
        }

        [Test]
        public void ListWith1ReturnsOneSteak()
        {
            var order = new Order<Dish>(
                new List<Dish>
                {
                    new Dish { Name = DishName.Steak, Count = 1 }
                });

            var actual = _sut.GetDishes(order);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(DishName.Steak, actual.First().Name);
            Assert.AreEqual(1, actual.First().Count);
        }
    }
}
