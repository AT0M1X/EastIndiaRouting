using CESAPI.Context;
using CESAPI.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace CESAPI.Data
{
    public class RoleDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public RoleDao(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<Role> GetAllRoles()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Roles.ToList();
            }
        }

        public Role GetRole(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Roles.Where(r => r.RoleID == id).FirstOrDefault();
            }
        }

        public Role GetRole(string name)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Roles.Where(r => r.RoleName == name).FirstOrDefault();
            }
        }

        public void AddRole(Role role)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                routingContext.Add(role);
                routingContext.SaveChanges();
            }
        }
    }
}
