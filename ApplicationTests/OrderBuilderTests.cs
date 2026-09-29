using Application.Builders;
using Application.Exceptions;
using Application.Mappers;
using Application.Models;
using NUnit.Framework;
using System.Linq;

namespace ApplicationTests
{
    [TestFixture]
    public class OrderBuilderTests
    {
        private OrderBuilder _sut;

        [SetUp]
        public void Setup()
        {
            var dishDescriptorBuilder = new DishDescriptorBuilder(
                new DishNameToTypeMapper(),
                new DishTypeToPositionMapper(),
                new DishNameToConstraintsMapper());

            _sut = new OrderBuilder(dishDescriptorBuilder);
        }

        [Test]
        public void BuildAggregatesDuplicateDishNamesIntoSingleDishWithCount()
        {
            var order = _sut.Build(new[] { DishName.Potato, DishName.Potato, DishName.Steak });

            var potato = order.Dishes.Single(dish => dish.Name == DishName.Potato);
            var steak = order.Dishes.Single(dish => dish.Name == DishName.Steak);

            Assert.AreEqual(2, potato.Count);
            Assert.AreEqual(1, steak.Count);
            Assert.AreEqual(2, order.Dishes.Length);
        }

        [Test]
        public void BuildPopulatesDishTypePositionConstraintsAndCount()
        {
            var order = _sut.Build(new[] { DishName.Steak });

            var dish = order.Dishes.Single();

            Assert.AreEqual(DishName.Steak, dish.Name);
            Assert.AreEqual(DishType.Entree, dish.Type);
            Assert.AreEqual(1, dish.Position);
            Assert.AreEqual(1, dish.Count);
            Assert.IsNotNull(dish.Constraints);
            Assert.AreEqual(1, dish.Constraints.MaxCountAllowed);
        }

        [Test]
        public void BuildUsesUnlimitedConstraintForPotato()
        {
            var order = _sut.Build(new[] { DishName.Potato, DishName.Potato });

            var dish = order.Dishes.Single();

            Assert.AreEqual(DishName.Potato, dish.Name);
            Assert.AreEqual(2, dish.Count);
            Assert.IsNotNull(dish.Constraints);
            Assert.IsNull(dish.Constraints.MaxCountAllowed);
        }

        [Test]
        public void BuildThrowsWhenDishNamesAreEmpty()
        {
            Assert.Throws<InvalidOrderException>(() => _sut.Build(Enumerable.Empty<DishName>()));
        }
    }
}
