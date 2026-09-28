using System;
using System.Collections.Generic;
using System.Linq;
using Application.Extensions;

namespace Application.Parsers
{
    public class IntParser : IIntParser
    {
        public string DefaultSeparator => ",";

        public IEnumerable<int> Parse(string source)
        {
            return Parse(source, DefaultSeparator);
        }

        public IEnumerable<int> Parse(string source, string separator)
        {
            source = source?.Trim();

            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentOutOfRangeException(nameof(source), "Input must be a comma separated list of numbers");

            separator = separator?.Trim();

            if (string.IsNullOrWhiteSpace(separator)) separator = DefaultSeparator;

            var items = source.Split(separator)
                .Where(item => !string.IsNullOrWhiteSpace(item));

            if (items.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException(nameof(items), "Input must contain at least one number");

            foreach (var item in items)
            {
                var success = int.TryParse(item, out int parsedItem);

                if (success)
                    yield return parsedItem;
                else
                    throw new ArgumentOutOfRangeException($"Parsing failed. Expected an integer, but received a '{item}'");
            }
        }
    }
}
