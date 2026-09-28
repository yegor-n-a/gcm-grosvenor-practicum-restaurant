using Application.Extensions;
using Application.Interfaces.General;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Validators
{
    public class MenuValidator : IMenuValidator
    {
        public IDictionary<int, IValidatableItem<string>> Validate(Menu menu, IEnumerable<int> orderedItemIds)
        {
            if (menu == null)
                throw new ArgumentOutOfRangeException(nameof(menu), "Menu cannot be undefined.");

            if (orderedItemIds.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException(nameof(orderedItemIds), "List of ordered items cannot be empty.");

            var result = new Dictionary<int, IValidatableItem<string>>();

            foreach (var itemId in orderedItemIds)
            {
                if (!menu.Items.ContainsKey(itemId))
                {
                    var validatableItem = new ValidatableItem<string>($"Dish # {itemId} is not available for order.");
                    result[itemId] = validatableItem;
                }
                else
                {
                    result[itemId] = new ValidatableItem<string>(Enumerable.Empty<string>());
                }
            }

            return result;
        }
    }
}
