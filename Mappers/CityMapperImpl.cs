using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public class CityMapperImpl : ICityMapper
    {
        public CityDto MapCityModelToDto(City city)
        {
            if (city == null)
            {
                return null;
            }
            return new CityDto() { Id = city.CityID, Name = city.CityName};
        }

        public List<CityDto> MapCityModelsToDtos(List<City> cities)
        {
            var citiesDto = new List<CityDto>();
            foreach(City c in cities)
            {
                citiesDto.Add(MapCityModelToDto(c));
            }
            return citiesDto;
        }
    }
}
