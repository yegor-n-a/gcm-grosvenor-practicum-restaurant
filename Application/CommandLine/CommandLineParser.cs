using PowerArgs;
using System;

namespace Application.CommandLine
{
    public class CommandLineParser
    {
        public static RestaurantCmdParams Parse(string[] args)
        {
            try
            {
                var options = Args.Parse<RestaurantCmdOptions>(args);

                return new RestaurantCmdParams(options);
            }
            catch (ArgException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<RestaurantCmdOptions>());
                return null;
            }
        }
    }
}
