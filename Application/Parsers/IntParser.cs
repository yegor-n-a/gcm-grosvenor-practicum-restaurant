using Application.Exceptions;
using Application.Extensions;
using System.Collections.Generic;
using System.Linq;

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
                throw new InvalidOrderException("Input must be a comma separated list of numbers");

            separator = separator?.Trim();

            if (string.IsNullOrWhiteSpace(separator)) separator = DefaultSeparator;

            var items = source.Split(separator)
                .Where(item => !string.IsNullOrWhiteSpace(item));

            if (items.IsNullOrEmpty())
                throw new InvalidOrderException("Input must contain at least one number");

            foreach (var item in items)
            {
                var success = int.TryParse(item, out int parsedItem);

                if (success)
                    yield return parsedItem;
                else
                    throw new InvalidOrderException($"Parsing failed. Expected an integer, but received a '{item}'");
            }
        }
    }
}
