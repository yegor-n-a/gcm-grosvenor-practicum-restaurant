using Application;
using Application.Builders;
using Application.CommandLine;
using Application.Mappers;
using Application.Parsers;
using Application.Printers;
using Application.Resolvers;
using Application.Sorters;
using Application.Validators;
using System;

namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderRequest = CommandLineParser.Parse(args);

            if (orderRequest == null)
                throw new ArgumentNullException("To proceed, you must specify part of the day & order");

            var dishManager = new DishManager(
                new DishValidator(),
                new DishSorter()
            );

            var menuBuilder = new MenuBuilder(
                new PartOfTheDayResolver(),
                new PartOfTheDayToMenuItemsMapper()
            );

            var dishDescriptorBuilder = new DishDescriptorBuilder(
                new DishNameResolver(),
                new DishTypeResolver(),
                new DishNameToTypeMapper(),
                new DishTypeToPositionMapper(),
                new DishNameToConstraintsMapper()
            );

            var server = new Server(
                dishManager,
                new IntParser(),
                menuBuilder,
                new MenuValidator(),
                new OrderBuilder(dishDescriptorBuilder),
                new DishPrinter());

            var output = server.TakeOrder(orderRequest);

            Console.WriteLine(output);
        }
    }
}
