using EIT.Context;
using EIT.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
{
    public class UserDao
    {
        private RoutingContext _routingContext;
        public UserDao(IServiceScopeFactory serviceScopeFactory) 
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
            }
        }

        public List<User> GetAllUsers()
        {
            return _routingContext.Users.ToList();
        }

        public List<User> GetUsersByRole(Role role)
        {
            return _routingContext.Users.Where(u => u.Role == role).ToList();
        }

        public User GetUser(int id)
        {
            return _routingContext.Users.Where(u => u.UserID == id).FirstOrDefault();
        }

        public User GetUser(string username)
        {
            return _routingContext.Users.Where(u => u.UserName == username).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _routingContext.Add(user);
            _routingContext.SaveChanges();
        }
    }
}
