using Application.Models;
using Application.Models.General;
using Application.Sorters;
using NUnit.Framework;
using System;
using System.Linq;

namespace ApplicationTests
{
    [TestFixture]
    public class DishSorterTests
    {
        private DishSorter _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DishSorter();
        }

        [Test]
        public void SortOrdersDishesByAscendingPosition()
        {
            var dishes = new[]
            {
                new Dish { Name = DishName.Cake, Position = 4, Count = 1 },
                new Dish { Name = DishName.Steak, Position = 1, Count = 1 },
                new Dish { Name = DishName.Wine, Position = 3, Count = 1 },
                new Dish { Name = DishName.Potato, Position = 2, Count = 1 }
            };

            var actual = _sut.Sort(dishes, SortDirection.Ascending).Select(dish => dish.Name).ToArray();

            Assert.AreEqual(new[] { DishName.Steak, DishName.Potato, DishName.Wine, DishName.Cake }, actual);
        }

        [Test]
        public void SortOrdersDishesByDescendingPosition()
        {
            var dishes = new[]
            {
                new Dish { Name = DishName.Steak, Position = 1, Count = 1 },
                new Dish { Name = DishName.Potato, Position = 2, Count = 1 },
                new Dish { Name = DishName.Wine, Position = 3, Count = 1 }
            };

            var actual = _sut.Sort(dishes, SortDirection.Descending).Select(dish => dish.Name).ToArray();

            Assert.AreEqual(new[] { DishName.Wine, DishName.Potato, DishName.Steak }, actual);
        }

        [Test]
        public void SortMissingPositionsAfterKnownPositions()
        {
            var coffee = new Dish { Name = DishName.Coffee, Position = null, Count = 1 };
            var dishes = new[]
            {
                coffee,
                new Dish { Name = DishName.Egg, Position = 1, Count = 1 }
            };

            var actual = _sut.Sort(dishes, SortDirection.Ascending).ToArray();

            Assert.AreEqual(DishName.Egg, actual[0].Name);
            Assert.AreEqual(DishName.Coffee, actual[1].Name);
            Assert.IsNull(coffee.Position);
        }

        [Test]
        public void SortThrowsForEmptyCollection()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Sort(Array.Empty<Dish>(), SortDirection.Ascending));
        }

        [Test]
        public void SortThrowsForInvalidSortDirection()
        {
            var dishes = new[]
            {
                new Dish { Name = DishName.Steak, Position = 1, Count = 1 }
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Sort(dishes, SortDirection.None));
        }
    }
}
