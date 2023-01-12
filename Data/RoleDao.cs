using EIT.Context;
using EIT.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
{
    public class RoleDao
    {
        private RoutingContext _routingContext;
        public RoleDao(IServiceScopeFactory serviceScopeFactory) 
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
            }
        }

        public List<Role> GetAllRoles()
        {
            return _routingContext.Roles.ToList();
        }

        public Role GetRole(int id)
        {
            return _routingContext.Roles.Where(r => r.RoleID == id).FirstOrDefault();
        }

        public Role GetRole(string name)
        {
            return _routingContext.Roles.Where(r => r.RoleName == name).FirstOrDefault();
        }

        public void AddRole(Role role)
        {
            _routingContext.Add(role);
            _routingContext.SaveChanges();
        }
    }
}
