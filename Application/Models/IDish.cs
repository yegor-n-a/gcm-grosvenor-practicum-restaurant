using Application.Interfaces.General;

namespace Application.Models
{
    public interface IDish : IDishDescriptor, ICountableItem<int> { }
}
