using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public class CityMapperImpl : ICityMapper
    {
        public CityDto mapCityModelToDto(City city)
        {
            if (city == null)
            {
                return null;
            }
            return new CityDto() { Id = city.CityID, Name = city.Cityname};
        }

        public List<CityDto> mapCityModelsToDtos(List<City> cities)
        {
            var citiesDto = new List<CityDto>();
            foreach(City c in cities)
            {
                citiesDto.Add(mapCityModelToDto(c));
            }
            return citiesDto;
        }
    }
}
