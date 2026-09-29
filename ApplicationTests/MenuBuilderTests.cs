using Application.Builders;
using Application.Mappers;
using Application.Models;
using Application.Resolvers;
using NUnit.Framework;
using System;

namespace ApplicationTests
{
    [TestFixture]
    public class MenuBuilderTests
    {
        private MenuBuilder _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new MenuBuilder(
                new PartOfTheDayResolver(),
                new PartOfTheDayToMenuItemsMapper());
        }

        [TestCase("morning")]
        [TestCase("Morning")]
        [TestCase(" morning ")]
        public void BuildResolvesMorningMenuCaseInsensitively(string partOfTheDay)
        {
            var actual = _sut.Build(partOfTheDay);

            Assert.AreEqual(DishName.Egg, actual.Items[1]);
            Assert.AreEqual(DishName.Toast, actual.Items[2]);
            Assert.AreEqual(DishName.Coffee, actual.Items[3]);
            Assert.IsFalse(actual.Items.ContainsKey(4));
        }

        [TestCase("evening")]
        [TestCase("Evening")]
        [TestCase(" evening ")]
        public void BuildResolvesEveningMenuCaseInsensitively(string partOfTheDay)
        {
            var actual = _sut.Build(partOfTheDay);

            Assert.AreEqual(DishName.Steak, actual.Items[1]);
            Assert.AreEqual(DishName.Potato, actual.Items[2]);
            Assert.AreEqual(DishName.Wine, actual.Items[3]);
            Assert.AreEqual(DishName.Cake, actual.Items[4]);
        }

        [Test]
        public void BuildThrowsForUnsupportedPartOfTheDay()
        {
            Assert.Throws<ArgumentException>(() => _sut.Build("lunch"));
        }

        [Test]
        public void GetPartOfTheDayReturnsNoneForUnsupportedPartOfTheDay()
        {
            var actual = _sut.GetPartOfTheDay("lunch");

            Assert.AreEqual(PartOfTheDay.None, actual);
        }
    }
}
