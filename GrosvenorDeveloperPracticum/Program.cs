using Application;
using Application.CommandLine;
using System;

namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmdParams = CommandLineParser.Parse(args);

            if (cmdParams == null) throw new ArgumentNullException("To proceed, you must specify part of the day & order");

            var server = new Server(new DishManager());

            while (true)
            {
                var unparsedOrder = Console.ReadLine();
                var output = server.TakeOrder(unparsedOrder);
                Console.WriteLine(output);
            }
        }
    }
}
