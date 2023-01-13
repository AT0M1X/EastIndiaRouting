using CESAPI.DTOs;
using CESAPI.Model;

namespace CESAPI.Mappers
{
    public interface IServiceAccountMapper
    {
        public ServiceAccountDto MapServiceAccountModelToDto(ServiceAccount serviceAccountDto);
    }
}
