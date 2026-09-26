namespace Application.Interfaces.General
{
    public interface IPositionedItem<T>
    {
        T Position { get; set; }
    }
}
