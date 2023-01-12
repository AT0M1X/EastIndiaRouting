using EIT.DTOs;

namespace EIT.Mappers
{
    public class CityMapperImpl : ICityMapper
    {
        public CityDto mapCityModelToDto()
        {
            return new CityDto() { Id = 1, Name = "test"};
        }
    }
}
