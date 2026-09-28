using Application.Models;

namespace Application.Resolvers
{
    public class PartOfTheDayResolver : StringResolver<PartOfTheDay>, IPartOfTheDayResolver
    {
        public override PartOfTheDay Resolve(string name)
        {
            name = name?.Trim();

            if (string.IsNullOrWhiteSpace(name)) return PartOfTheDay.None;

            var success = PartOfTheDay.TryFromName(name, IgnoreCase, out var nameValue);

            return success
                ? nameValue
                : PartOfTheDay.None;
        }
    }
}
