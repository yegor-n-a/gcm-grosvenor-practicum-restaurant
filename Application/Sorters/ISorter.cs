using Application.Models.General;

namespace Application.Sorters
{
    public interface ISorter<TInput, TOutput>
    {
        public TOutput Sort(TInput source, SortDirection sortDirection);
    }
}
