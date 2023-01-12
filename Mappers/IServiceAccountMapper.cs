using EIT.DTOs;
using EIT.Model;

namespace EIT.Mappers
{
    public interface IServiceAccountMapper
    {
        public ServiceAccountDto MapServiceAccountModelToDto(ServiceAccount serviceAccountDto);
    }
}
