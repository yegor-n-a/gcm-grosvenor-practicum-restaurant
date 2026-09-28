using Application.Mappers;
using Application.Models;
using Application.Constraints;
using Application.Resolvers;
using System;

namespace Application.Builders
{
    public class DishDescriptorBuilder : IDishDescriptorBuilder
    {
        private IDishNameResolver DishNameResolver { get; }
        private IDishTypeResolver DishTypeResolver { get; }
        private IDishNameToTypeMapper DishNameToTypeMapper { get; }
        private IDishTypeToPositionMapper DishTypeToPositionMapper { get; }
        private IDishNameToConstraintsMapper DishNameToConstraintsMapper { get; }

        public DishDescriptorBuilder(
            IDishNameResolver dishNameResolver,
            IDishTypeResolver dishTypeResolver,
            IDishNameToTypeMapper dishNameToTypeMapper,
            IDishTypeToPositionMapper dishTypeToPositionMapper,
            IDishNameToConstraintsMapper dishNameToConstraintsMapper)
        {
            DishNameResolver = dishNameResolver;
            DishTypeResolver = dishTypeResolver;
            DishNameToTypeMapper = dishNameToTypeMapper;
            DishTypeToPositionMapper = dishTypeToPositionMapper;
            DishNameToConstraintsMapper = dishNameToConstraintsMapper;
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

        public DishConstraints BuildConstraints(DishName dishName)
        {
            return DishNameToConstraintsMapper.Map(dishName);
        }

        public DishDescriptor Build(int dishId)
        {
            var dishName = BuildName(dishId);

            if (dishName == DishName.None)
                throw new ArgumentException($"Dish with id = '{dishId}' not found.");

            var dishType = BuildType(dishName);

            if (dishType == DishType.None)
                throw new ArgumentException($"Dish: '{dishName}' does not have a valid type.");

            var position = BuildPosition(dishType);

            var constraints = BuildConstraints(dishName);

            return new DishDescriptor
            {
                Name = dishName,
                Type = dishType,
                Position = position,
                Constraints = constraints
            };
        }
    }
}
