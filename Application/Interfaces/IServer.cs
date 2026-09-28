using Application.Models;

namespace Application
{
    public interface IServer
    {
        string TakeOrder(OrderRequest orderRequest);
    }
}