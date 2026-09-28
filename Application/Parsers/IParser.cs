namespace Application.Parsers
{
    public interface IParser<TInput, TOutput>
    {
        public TOutput Parse(TInput input);
    }
}
