using System;

namespace Application.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException(string message)
            : base(message)
        { }
    }
}
