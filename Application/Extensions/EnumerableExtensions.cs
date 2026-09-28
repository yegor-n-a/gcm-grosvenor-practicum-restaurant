using System.Collections.Generic;
using System.Linq;

namespace Application.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return !source?.Any() ?? true;
        }

        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source)
        {
            return source?
                .GroupBy(item => item)
                .Where(groupedItems => groupedItems.Count() > 1)
                .SelectMany(groupedItems => groupedItems);
        }
    }
}
