using CESAPI.Context;
using CESAPI.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace CESAPI.Data
{
    public class UserDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public UserDao(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<User> GetAllUsers()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Users.ToList();
            }
        }

        public List<User> GetUsersByRole(Role role)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Users.Where(u => u.Role == role).ToList();
            }
        }

        public User GetUser(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Users.Where(u => u.UserID == id).FirstOrDefault();
            }
        }

        public User GetUser(string username)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Users.Where(u => u.UserName == username).FirstOrDefault();
            }
        }

        public void AddUser(User user)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                routingContext.Add(user);
                routingContext.SaveChanges();
            }
        }
    }
}
