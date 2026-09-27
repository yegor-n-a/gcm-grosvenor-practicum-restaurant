using Application.Models;

namespace Application.Builders
{
    public interface IDishDescriptorBuilder : IBuilder<DishDescriptor, int>
    {
        public DishName BuildName(int id);
        public DishType BuildType(DishName name);
        public decimal? BuildPosition(DishType type);
    }
}
