using System.Collections.Generic;

namespace Application.Interfaces.General
{
    public interface IValidatableItem<TError>
    {
        IReadOnlyCollection<TError> Errors { get; }
        bool IsValid { get; }
    }
}
