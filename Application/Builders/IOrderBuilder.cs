using System;
using Application.Models;

namespace Application.Builders
{
    public interface IOrderBuilder<T> : IBuilder<_Order<T>, string> { }

    public class OrderBuilder<T> : IOrderBuilder<T>
    {
        public _Order<T> Build(string source)
        {
            throw new NotImplementedException();
        }
    }
}
