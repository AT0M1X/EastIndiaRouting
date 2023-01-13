using CESAPI.Data;
using CESAPI.DTOs;
using CESAPI.Model;

namespace CESAPI.Mappers
{
    public interface ICityMapper
    {
        public CityDto MapCityModelToDto(City city);

        public List<CityDto> MapCityModelsToDtos(List<City> cities);
    }
}
