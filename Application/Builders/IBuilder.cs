namespace Application.Builders
{
    public interface IBuilder<TModel, TSource>
    {
        public TModel Build(TSource source);
    }
}
