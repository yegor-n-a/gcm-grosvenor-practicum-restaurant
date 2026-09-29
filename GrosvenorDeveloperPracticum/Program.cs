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

            Console.WriteLine(output);
        }
    }
}
