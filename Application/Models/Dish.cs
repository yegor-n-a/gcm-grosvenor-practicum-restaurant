namespace Application.Models
{
    public class Dish : DishDescriptor, IDish
    {
        public int Count { get; set; }
    }
}