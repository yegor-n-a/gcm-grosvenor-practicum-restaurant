namespace Application.Interfaces.General
{
    public interface ICountableItem<T>
    {
        T Count { get; set; }
    }
}
