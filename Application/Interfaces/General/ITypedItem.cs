namespace Application.Interfaces.General
{
    public interface ITypedItem<T>
    {
        T Type { get; set; }
    }
}
