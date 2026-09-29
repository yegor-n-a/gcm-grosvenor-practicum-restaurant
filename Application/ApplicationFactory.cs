using Application.Builders;
using Application.Mappers;
using Application.Parsers;
using Application.Printers;
using Application.Resolvers;
using Application.Sorters;
using Application.Validators;

namespace Application
{
    public static class ApplicationFactory
    {
        public static IServer CreateServer()
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

            return new Server(
                dishManager,
                new IntParser(),
                menuBuilder,
                new MenuValidator(),
                new OrderBuilder(dishDescriptorBuilder),
                new DishPrinter());
        }
    }
}
