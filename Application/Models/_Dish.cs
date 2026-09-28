namespace Application.Models
{
    public class _Dish : DishDescriptor, IDish
    {
        public int Count { get; set; }
    }
}