using EIT.Context;
using EIT.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
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
