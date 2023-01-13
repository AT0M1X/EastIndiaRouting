using CESAPI.Data;
using CESAPI.DTOs;
using CESAPI.Mappers;
using System.Collections.Generic;

namespace CESAPI.Service
{
    public class WeightClassService
    {
        private readonly IWeightClassMapper _weightClassMapper;
        private readonly WeightClassDao _weightClassDao;

        public WeightClassService(IWeightClassMapper weightClassMapper, WeightClassDao weightClassDao)
        {
            _weightClassMapper = weightClassMapper;
            _weightClassDao = weightClassDao;
        }

        public List<WeightClassDto> GetWeightClasses()
        {
            var weightClassModels = _weightClassDao.GetAllWeightClasses();
            return _weightClassMapper.MapWeightClassModelsToDtos(weightClassModels);
        }
    }
}
