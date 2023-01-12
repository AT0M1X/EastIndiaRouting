using EIT.Context;
using EIT.Data;
using EIT.DTOs;
using EIT.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace EIT.Service
{
    public class CityService
    {
        private readonly ICityMapper _cityMapper;
        private readonly CityDao _cityDao;
        public CityService(ICityMapper cityMapper, IServiceScopeFactory serviceScopeFactory)
        {
            _cityMapper = cityMapper;
            _cityDao = new CityDao(serviceScopeFactory);
        }

        public List<CityDto> GetCities()
        {
            var cities = _cityDao.GetAllCities();
            return _cityMapper.MapCityModelsToDtos(cities);
        }

        public CityDto GetCity(int city)
        {
            var cityModel = _cityDao.GetCity(city);
            return _cityMapper.MapCityModelToDto(cityModel);
        }
    }
}
