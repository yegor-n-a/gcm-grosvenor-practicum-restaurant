namespace Application.Resolvers
{
    public interface IStringResolver<T> : IResolver<T, string>
    {
        public bool IgnoreCase { get; }
    }
}
