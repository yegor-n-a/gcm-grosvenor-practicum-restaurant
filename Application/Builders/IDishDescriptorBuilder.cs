using Application.Models;

namespace Application.Builders
{
    public interface IDishDescriptorBuilder : IBuilder<DishDescriptor, string>
    {
        public DishName BuildName(string name);
        public DishType BuildType(DishName name);
        public decimal? BuildPosition(DishType type);
    }
}
