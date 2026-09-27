namespace Application.Resolvers
{
    public abstract class StringResolver<T> : IStringResolver<T>
    {
        public virtual bool IgnoreCase { get; protected set; }

        public abstract T Resolve(string input);

        protected StringResolver() : this(true) { }

        protected StringResolver(bool ignoreCase)
        {
            IgnoreCase = ignoreCase;
        }
    }
}
