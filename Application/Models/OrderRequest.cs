using Application.CommandLine;

namespace Application.Models
{
    public class OrderRequest
    {
        public string Order { get; }
        public string PartOfTheDay { get; }

        public OrderRequest(OrderCmdDetails details)
        {
            Order = details.Order;
            PartOfTheDay = details.PartOfTheDay;
        }
    }
}
