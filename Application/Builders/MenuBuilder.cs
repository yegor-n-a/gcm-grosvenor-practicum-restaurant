using Application.Mappers;
using Application.Models;
using Application.Resolvers;

namespace Application.Builders
{
    public class MenuBuilder : IMenuBuilder
    {
        private IPartOfTheDayResolver PartOfTheDayResolver { get; }
        private IPartOfTheDayToMenuItemsMapper PartOfTheDayToMenuItemsMapper { get; }

        public MenuBuilder(
            IPartOfTheDayResolver partOfTheDayResolver,
            IPartOfTheDayToMenuItemsMapper partOfTheDayToMenuItemsMapper)
        {
            PartOfTheDayResolver = partOfTheDayResolver;
            PartOfTheDayToMenuItemsMapper = partOfTheDayToMenuItemsMapper;
        }

        public PartOfTheDay GetPartOfTheDay(string partOfTheDay)
        {
            return PartOfTheDayResolver.Resolve(partOfTheDay);
        }

        public Menu Build(string name)
        {
            var partOfTheDay = GetPartOfTheDay(name);

            if (partOfTheDay == null) return null;

            var items = PartOfTheDayToMenuItemsMapper.Map(partOfTheDay);

            return new Menu(items);
        }
    }
}
