using EIT.Data;
using EIT.DTOs;
using EIT.Mappers;
using System.Collections.Generic;

namespace EIT.Service
{
    public class CityService
    {
        private readonly ICityMapper _cityMapper;
        private readonly CityDao _cityDao;
        public CityService(ICityMapper cityMapper, CityDao cityDao)
        {
            _cityMapper = cityMapper;
            _cityDao = cityDao;
        }

        public List<CityDto> GetCities()
        {
            var cities = _cityDao.GetAllCities();
            return _cityMapper.mapCityModelsToDtos(cities);
        }
    }
}
