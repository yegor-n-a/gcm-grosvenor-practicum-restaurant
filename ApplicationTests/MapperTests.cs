using Application.Mappers;
using Application.Models;
using NUnit.Framework;

namespace ApplicationTests
{
    [TestFixture]
    public class MapperTests
    {
        [Test]
        public void PartOfTheDayToMenuItemsMapperMapsMorningMenuToReadmeIds()
        {
            var sut = new PartOfTheDayToMenuItemsMapper();

            var actual = sut.Map(PartOfTheDay.Morning);

            Assert.AreEqual(DishName.Egg, actual[1]);
            Assert.AreEqual(DishName.Toast, actual[2]);
            Assert.AreEqual(DishName.Coffee, actual[3]);
            Assert.IsFalse(actual.ContainsKey(4));
        }

        [Test]
        public void PartOfTheDayToMenuItemsMapperMapsEveningMenuToReadmeIds()
        {
            var sut = new PartOfTheDayToMenuItemsMapper();

            var actual = sut.Map(PartOfTheDay.Evening);

            Assert.AreEqual(DishName.Steak, actual[1]);
            Assert.AreEqual(DishName.Potato, actual[2]);
            Assert.AreEqual(DishName.Wine, actual[3]);
            Assert.AreEqual(DishName.Cake, actual[4]);
        }

        [TestCaseSource(nameof(DishTypeMappings))]
        public void DishNameToTypeMapperMapsDishesToExpectedTypes(DishName dishName, DishType expectedType)
        {
            var sut = new DishNameToTypeMapper();

            var actual = sut.Map(dishName);

            Assert.AreEqual(expectedType, actual);
        }

        [TestCaseSource(nameof(DishTypePositionMappings))]
        public void DishTypeToPositionMapperMapsTypesToExpectedOutputPositions(DishType dishType, decimal expectedPosition)
        {
            var sut = new DishTypeToPositionMapper();

            var actual = sut.Map(dishType);

            Assert.AreEqual(expectedPosition, actual);
        }

        [TestCaseSource(nameof(DishConstraintMappings))]
        public void DishNameToConstraintsMapperMapsExpectedMaxCount(DishName dishName, int? expectedMaxCount)
        {
            var sut = new DishNameToConstraintsMapper();

            var actual = sut.Map(dishName);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedMaxCount, actual.MaxCountAllowed);
        }

        private static object[] DishTypeMappings => new object[]
        {
            new object[] { DishName.Egg, DishType.Entree },
            new object[] { DishName.Steak, DishType.Entree },
            new object[] { DishName.Toast, DishType.Side },
            new object[] { DishName.Potato, DishType.Side },
            new object[] { DishName.Coffee, DishType.Drink },
            new object[] { DishName.Wine, DishType.Drink },
            new object[] { DishName.Cake, DishType.Dessert }
        };

        private static object[] DishTypePositionMappings => new object[]
        {
            new object[] { DishType.Entree, 1m },
            new object[] { DishType.Side, 2m },
            new object[] { DishType.Drink, 3m },
            new object[] { DishType.Dessert, 4m }
        };

        private static object[] DishConstraintMappings => new object[]
        {
            new object[] { DishName.Egg, 1 },
            new object[] { DishName.Steak, 1 },
            new object[] { DishName.Toast, 1 },
            new object[] { DishName.Potato, null },
            new object[] { DishName.Coffee, null },
            new object[] { DishName.Wine, 1 },
            new object[] { DishName.Cake, 1 }
        };
    }
}
