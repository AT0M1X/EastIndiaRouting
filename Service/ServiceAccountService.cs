using EIT.Data;
using EIT.DTOs;
using EIT.Mappers;
using System;

namespace EIT.Service
{
    public class ServiceAccountService
    {
        private readonly IServiceAccountMapper _serviceAccountMapper;
        private readonly ServiceAccountDao _serviceAccountDao;

        public ServiceAccountService(IServiceAccountMapper serviceAccountMapper, ServiceAccountDao serviceAccountDao)
        {
            _serviceAccountMapper = serviceAccountMapper;
            _serviceAccountDao = serviceAccountDao;
        }

        public ServiceAccountDto GetServiceAccount(Guid collaborationID)
        {
            var serviceAccount = _serviceAccountDao.GetServiceAccount(collaborationID);
            return _serviceAccountMapper.MapServiceAccountModelToDto(serviceAccount);
        }
    }
}
