namespace Application.CommandLine
{
    public class RestaurantCmdParams
    {
        public string Order { get; }
        public string PartOfTheDay { get; }

        public RestaurantCmdParams(RestaurantCmdOptions options)
        {
            Order = options.Order;
            PartOfTheDay = options.PartOfTheDay;
        }
    }
}
