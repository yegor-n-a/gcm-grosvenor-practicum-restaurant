namespace Application.Resolvers
{
    public interface IResolver<TModel, TInput>
    {
        public TModel Resolve(TInput input);
    }
}
