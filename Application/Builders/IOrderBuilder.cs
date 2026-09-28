using Application.Models;

namespace Application.Builders
{
    public interface IOrderBuilder : IBuilder<_Order<_Dish>, string> { }
}
