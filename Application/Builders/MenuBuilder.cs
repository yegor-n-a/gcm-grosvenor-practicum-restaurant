using Application.Extensions;
using Application.Mappers;
using Application.Models;
using Application.Resolvers;
using System;

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

            if (partOfTheDay == null)
                throw new ArgumentException($"Menu: '{name}' not found.");

            var items = PartOfTheDayToMenuItemsMapper.Map(partOfTheDay);

            if (items.IsNullOrEmpty())
                throw new ArgumentException($"Menu: '{name}' does not contain any items.");

            return new Menu(items);
        }
    }
}
