using Application.Models;
using PowerArgs;
using System;

namespace Application.CommandLine
{
    public class CommandLineParser
    {
        public static OrderRequest Parse(string[] args)
        {
            try
            {
                var orderDetails = Args.Parse<OrderCmdDetails>(args);

                return new OrderRequest(orderDetails);
            }
            catch (ArgException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<OrderCmdDetails>());
                return null;
            }
        }
    }
}
