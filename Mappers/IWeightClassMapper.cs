using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface IWeightClassMapper
    {
        public WeightClassDto MapWeightClassModelToDto(WeightClass weightClass);

        public List<WeightClassDto> MapWeightClassModelsToDtos(List<WeightClass> weightClasses);
    }
}
