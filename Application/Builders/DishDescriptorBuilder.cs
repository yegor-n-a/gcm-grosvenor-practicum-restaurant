using Application.Constraints;
using Application.Mappers;
using Application.Models;

namespace Application.Builders
{
    public class DishDescriptorBuilder : IDishDescriptorBuilder
    {
        private IDishNameToTypeMapper DishNameToTypeMapper { get; }
        private IDishTypeToPositionMapper DishTypeToPositionMapper { get; }
        private IDishNameToConstraintsMapper DishNameToConstraintsMapper { get; }

        public DishDescriptorBuilder(
            IDishNameToTypeMapper dishNameToTypeMapper,
            IDishTypeToPositionMapper dishTypeToPositionMapper,
            IDishNameToConstraintsMapper dishNameToConstraintsMapper)
        {
            DishNameToTypeMapper = dishNameToTypeMapper;
            DishTypeToPositionMapper = dishTypeToPositionMapper;
            DishNameToConstraintsMapper = dishNameToConstraintsMapper;
        }

        public DishType BuildType(DishName dishName)
        {
            return DishNameToTypeMapper.Map(dishName);
        }

        public decimal? BuildPosition(DishType dishType)
        {
            return DishTypeToPositionMapper.Map(dishType);
        }

        public DishConstraints BuildConstraints(DishName dishName)
        {
            return DishNameToConstraintsMapper.Map(dishName);
        }
    }
}
