using Application.Exceptions;
using Application.Parsers;
using NUnit.Framework;
using System.Linq;

namespace ApplicationTests
{
    [TestFixture]
    public class IntParserTests
    {
        private IntParser _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new IntParser();
        }

        [Test]
        public void ParseReturnsIntegersFromCommaSeparatedInput()
        {
            var actual = _sut.Parse("1, 2, 3").ToArray();

            Assert.AreEqual(new[] { 1, 2, 3 }, actual);
        }

        [Test]
        public void ParseIgnoresEmptyEntries()
        {
            var actual = _sut.Parse("1,,2").ToArray();

            Assert.AreEqual(new[] { 1, 2 }, actual);
        }

        [Test]
        public void ParseUsesCustomSeparator()
        {
            var actual = _sut.Parse("1|2|3", "|").ToArray();

            Assert.AreEqual(new[] { 1, 2, 3 }, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(",")]
        public void ParseThrowsWhenInputDoesNotContainNumbers(string source)
        {
            Assert.Throws<InvalidOrderException>(() => _sut.Parse(source).ToArray());
        }

        [Test]
        public void ParseThrowsWhenInputContainsNonIntegerValue()
        {
            Assert.Throws<InvalidOrderException>(() => _sut.Parse("1,one,2").ToArray());
        }
    }
}
