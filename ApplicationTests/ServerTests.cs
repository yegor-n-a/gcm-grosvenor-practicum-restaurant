using Application;
using Application.Builders;
using Application.CommandLine;
using Application.Mappers;
using Application.Models;
using Application.Parsers;
using Application.Printers;
using Application.Resolvers;
using Application.Sorters;
using Application.Validators;
using NUnit.Framework;

namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;

        [SetUp]
        public void Setup()
        {
            var dishManager = new DishManager(
                new DishValidator(),
                new DishSorter()
            );

            var menuBuilder = new MenuBuilder(
                new PartOfTheDayResolver(),
                new PartOfTheDayToMenuItemsMapper()
            );

            var dishDescriptorBuilder = new DishDescriptorBuilder(
                new DishNameToTypeMapper(),
                new DishTypeToPositionMapper(),
                new DishNameToConstraintsMapper()
            );

            _sut = new Server(
                dishManager,
                new IntParser(),
                menuBuilder,
                new MenuValidator(),
                new OrderBuilder(dishDescriptorBuilder),
                new DishPrinter());
        }

        [TearDown]
        public void Teardown()
        {

        }

        private OrderRequest CreateEveningOrderRequest(string order)
        {
            return new OrderRequest(new OrderCmdDetails
            {
                PartOfTheDay = PartOfTheDay.Evening.Name,
                Order = order
            });
        }

        private OrderRequest CreateOrderRequest(string partOfTheDay, string order)
        {
            return new OrderRequest(new OrderCmdDetails
            {
                PartOfTheDay = partOfTheDay,
                Order = order
            });
        }

        [TestCase("morning", "1, 2, 3", "egg,toast,coffee")]
        [TestCase("Morning", "3,3,3", "coffee(x3)")]
        [TestCase("morning ", "1,3,2,3", "egg,toast,coffee(x2)")]
        [TestCase("morning", "1, 2, 2", "error")]
        [TestCase("morning", "1, 2, 4", "error")]
        [TestCase("evening", "1, 2, 3, 4", "steak,potato,wine,cake")]
        [TestCase("Evening", "1, 2, 2, 4", "steak,potato(x2),cake")]
        [TestCase("evening", "1, 2, 3, 5", "error")]
        [TestCase("evening", "1, 3, 2, 3", "error")]
        public void SampleInputsOfExpectedOutput(string partOfTheDay, string order, string expected)
        {
            var actual = _sut.TakeOrder(CreateOrderRequest(partOfTheDay, order));

            Assert.AreEqual(expected, actual);
        }

        [TestCase("afternoon", "1")]
        [TestCase("lunch", "1")]
        [TestCase("", "1")]
        [TestCase(" ", "1")]
        [TestCase("evening", "0")]
        [TestCase("evening", "-1")]
        [TestCase("evening", "999")]
        [TestCase("evening", "1,0,2")]
        [TestCase("evening", "1,-1,2")]
        [TestCase("evening", "1,999,2")]
        [TestCase("evening", "")]
        [TestCase("evening", " ")]
        [TestCase("evening", ",")]
        [TestCase("evening", ",,")]
        public void OutOfScopeInputsReturnError(string partOfTheDay, string order)
        {
            var actual = _sut.TakeOrder(CreateOrderRequest(partOfTheDay, order));

            Assert.AreEqual("error", actual);
        }

        [Test]
        public void ErrorGetsReturnedWithBadInput()
        {
            var order = "one";
            string expected = "error";
            var actual = _sut.TakeOrder(CreateEveningOrderRequest(order));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteak()
        {
            var order = "1";
            string expected = "steak";
            var actual = _sut.TakeOrder(CreateEveningOrderRequest(order));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServe2Potatoes()
        {
            var order = "2,2";
            string expected = "potato(x2)";
            var actual = _sut.TakeOrder(CreateEveningOrderRequest(order));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteakPotatoWineCake()
        {
            var order = "1,2,3,4";
            string expected = "steak,potato,wine,cake";
            var actual = _sut.TakeOrder(CreateEveningOrderRequest(order));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteakPotatox2Cake()
        {
            var order = "1,2,2,4";
            string expected = "steak,potato(x2),cake";
            var actual = _sut.TakeOrder(CreateEveningOrderRequest(order));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanGenerateErrorWithWrongDish()
        {
            var order = "1,2,3,5";
            string expected = "error";
            var actual = _sut.TakeOrder(CreateEveningOrderRequest(order));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanGenerateErrorWhenTryingToServerMoreThanOneSteak()
        {
            var order = "1,1,2,3";
            string expected = "error";
            var actual = _sut.TakeOrder(CreateEveningOrderRequest(order));
            Assert.AreEqual(expected, actual);
        }
    }
}