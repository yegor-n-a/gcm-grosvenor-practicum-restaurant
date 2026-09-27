using Application.Mappers;
using Application.Models;
using Application.Resolvers;

namespace Application.Builders
{
    public class DishDescriptorBuilder : IDishDescriptorBuilder
    {
        private IDishNameResolver DishNameResolver { get; }
        private IDishTypeResolver DishTypeResolver { get; }
        private IDishNameToTypeMapper DishNameToTypeMapper { get; }
        private IDishTypeToPositionMapper DishTypeToPositionMapper { get; }

        public DishDescriptorBuilder(
            IDishNameResolver dishNameResolver,
            IDishTypeResolver dishTypeResolver,
            IDishNameToTypeMapper dishNameToTypeMapper,
            IDishTypeToPositionMapper dishTypeToPositionMapper)
        {
            DishNameResolver = dishNameResolver;
            DishTypeResolver = dishTypeResolver;
            DishNameToTypeMapper = dishNameToTypeMapper;
            DishTypeToPositionMapper = dishTypeToPositionMapper;
        }

        public DishName BuildName(int dishId)
        {
            return DishNameResolver.Resolve(dishId);
        }

        public DishType BuildType(DishName dishName)
        {
            return DishNameToTypeMapper.Map(dishName);
        }

        public DishType BuildType(int dishId)
        {
            var nameValue = BuildName(dishId);

            return BuildType(nameValue);
        }

        public decimal? BuildPosition(DishType dishType)
        {
            return DishTypeToPositionMapper.Map(dishType);
        }

        public decimal? BuildPosition(string typeName)
        {
            var typeValue = DishTypeResolver.Resolve(typeName);

            return BuildPosition(typeValue);
        }

        public DishDescriptor Build(int dishId)
        {
            var dishName = BuildName(dishId);

            if (dishName == DishName.None) return null;

            var dishType = BuildType(dishName);

            if (dishType == DishType.None) return null;

            var position = BuildPosition(dishType);

            return new DishDescriptor
            {
                Name = dishName,
                Type = dishType,
                Position = position
            };
        }
    }
}
