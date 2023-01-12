﻿using EIT.DTOs;
using EIT.Model;

namespace EIT.Mappers
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
