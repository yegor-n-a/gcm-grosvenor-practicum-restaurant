namespace Application.Mappers
{
    public interface IMapper<TSource, TDestination>
    {
        public TDestination Map(TSource source);
    }
}
