using System.Collections.Immutable;

namespace Application.Interfaces.General
{
    public interface IValidatableItem<TError>
    {
        ImmutableArray<TError> Errors { get; }
        bool IsValid { get; }
    }
}
