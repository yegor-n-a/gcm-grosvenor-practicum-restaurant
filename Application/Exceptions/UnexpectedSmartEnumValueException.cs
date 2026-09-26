using Ardalis.SmartEnum;
using System;
using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    public class UnexpectedSmartEnumValueException<T> : Exception where T : SmartEnum<T>
    {
        public UnexpectedSmartEnumValueException(T item)
            : base($"Value '{item.Value}' of enum '{item.Name}' is not supported")
        { }

        protected UnexpectedSmartEnumValueException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
