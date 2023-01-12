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
        private RoutingContext _routingContext;
        public ServiceAccountDao(IServiceScopeFactory serviceScopeFactory) 
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
            }
        }

        public List<ServiceAccount> GetAllServiceAccounts()
        {
            return _routingContext.ServiceAccounts.ToList();
        }

        public ServiceAccount GetServiceAccount(int id)
        {
            return _routingContext.ServiceAccounts.Where(s => s.ServiceAccountID == id).FirstOrDefault();
        }

        public ServiceAccount GetServiceAccount(string name)
        {
            return _routingContext.ServiceAccounts.Where(s => s.CompanyName == name).FirstOrDefault();
        }

        public void AddServiceAccount(ServiceAccount ServiceAccount)
        {
            _routingContext.Add(ServiceAccount);
            _routingContext.SaveChanges();
        }
    }
}
