using CESAPI.Data;
using CESAPI.DTOs;
using CESAPI.Mappers;

namespace CESAPI.Service
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

        public CityDto GetCity(string city)
        {
            var cityModel = _cityDao.GetCity(city);
            return _cityMapper.MapCityModelToDto(cityModel);
        }
    }
}
