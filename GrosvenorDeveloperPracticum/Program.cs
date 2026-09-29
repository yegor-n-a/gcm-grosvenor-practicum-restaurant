using Application;
using Application.CommandLine;
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

            var server = ApplicationFactory.CreateServer();

            var output = server.TakeOrder(orderRequest);

            PrintABitFancier(output);
        }

        private static void PrintABitFancier(string output)
        {
            var originalColor = Console.ForegroundColor;

            Console.WriteLine();

            Console.ForegroundColor = output == "error"
                ? ConsoleColor.Red
                : ConsoleColor.Green;

            Console.WriteLine($"  {output}");
            Console.ForegroundColor = originalColor;
            Console.WriteLine();
        }
    }
}
