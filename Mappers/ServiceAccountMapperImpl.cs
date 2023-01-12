using EIT.DTOs;

namespace EIT.Mappers
{
    public class ServiceAccountMapperImpl : IServiceAccountMapper
    {
        public ServiceAccountDto MapServiceAccountModelToDto()
        {
            return new ServiceAccountDto();
        }
    }
}
