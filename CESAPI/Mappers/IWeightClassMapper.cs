using CESAPI.DTOs;
using CESAPI.Model;
using System.Collections.Generic;

namespace CESAPI.Mappers
{
    public interface IWeightClassMapper
    {
        public WeightClassDto MapWeightClassModelToDto(WeightClass weightClass);

        public List<WeightClassDto> MapWeightClassModelsToDtos(List<WeightClass> weightClasses);
    }
}
