using EIT.DTOs;
using EIT.Mappers;

namespace EIT.Service
{
    public class ServiceAccountService
    {
        private readonly IServiceAccountMapper _serviceAccountMapper;

        public ServiceAccountService(IServiceAccountMapper serviceAccountMapper)
        {
            _serviceAccountMapper = serviceAccountMapper;
        }

        public ServiceAccountDto GetServiceAccount()
        {
            return _serviceAccountMapper.MapServiceAccountModelToDto();
        }
    }
}
