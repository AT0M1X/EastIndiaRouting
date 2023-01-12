using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public class WeightClassMapperImpl : IWeightClassMapper
    {
        public WeightClassDto MapWeightClassModelToDto(WeightClass weightClass)
        {
            if  (weightClass == null)
            {
                return null;
            }
            return new WeightClassDto()
            {
                Id = weightClass.WeightClassID,
                MaximumWeight = weightClass.MaximumWeight,
                MinimumWeight = weightClass.MinimumWeight,
                Price = weightClass.Price
            };
        }

        public List<WeightClassDto> MapWeightClassModelsToDtos(List<WeightClass> weightClasses)
        {
            var weightClassDtos = new List<WeightClassDto>();
            foreach(var weightClass in weightClasses)
            {
                weightClassDtos.Add(MapWeightClassModelToDto(weightClass));
            }
            return weightClassDtos;
        }
    }
}
