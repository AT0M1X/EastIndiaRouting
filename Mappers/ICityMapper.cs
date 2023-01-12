using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface ICityMapper
    {
        public CityDto mapCityModelToDto(City city);

        public List<CityDto> mapCityModelsToDtos(List<City> cities);
    }
}
