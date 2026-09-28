using Application.Interfaces.General;
using Application.Models;
using System.Collections.Generic;

namespace Application.Validators
{
    public interface IMenuValidator
    {
        IDictionary<int, IValidatableItem<string>> Validate(Menu menu, IEnumerable<int> orderedItemIds);
    }
}
