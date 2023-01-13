using CESAPI.DTOs;
using CESAPI.Model;

namespace CESAPI.Mappers
{
    public class ServiceAccountMapperImpl : IServiceAccountMapper
    {
        public ServiceAccountDto MapServiceAccountModelToDto(ServiceAccount serviceAccount)
        {
            return new ServiceAccountDto { 
                Id = serviceAccount.ServiceAccountID,
                CompanyName = serviceAccount.CompanyName,
                CollaborationID = serviceAccount.CollaborationID,
            };
        }
    }
}
