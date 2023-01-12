using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface ICityMapper
    {
        public CityDto MapCityModelToDto(City city);

        public List<CityDto> MapCityModelsToDtos(List<City> cities);
    }
}
