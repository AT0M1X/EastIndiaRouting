﻿using CESAPI.Context;
using CESAPI.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CESAPI.Data
{
    public class ServiceAccountDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public ServiceAccountDao(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<ServiceAccount> GetAllServiceAccounts()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.ServiceAccounts.ToList();
            }
        }

        public ServiceAccount GetServiceAccount(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.ServiceAccounts.Where(s => s.ServiceAccountID == id).FirstOrDefault();
            }
        }

        public ServiceAccount GetServiceAccount(string name)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.ServiceAccounts.Where(s => s.CompanyName == name).FirstOrDefault();
            }
        }

        public ServiceAccount GetServiceAccount(Guid collaborationID)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.ServiceAccounts.Where(s => s.CollaborationID == collaborationID).FirstOrDefault();
            }
        }

        public void AddServiceAccount(ServiceAccount ServiceAccount)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                routingContext.Add(ServiceAccount);
                routingContext.SaveChanges();
            }
        }
    }
}
