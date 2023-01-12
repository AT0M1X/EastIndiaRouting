using EIT.Context;
using EIT.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
{
    public class RouteDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public RouteDao(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<Route> GetAllRoutes()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Routes.ToList();
            }
        }

        public Route GetRoute(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Routes.Where(r => r.RouteID == id).FirstOrDefault();
            }
        }

        public Route GetRoute(City origin, City destination)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Routes.Where(r => r.OriginCityCityId == origin.CityID && r.DestinationCityCityId == destination.CityID).FirstOrDefault();
            }
        }

        public void AddRoute(Route Route)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                routingContext.Add(Route);
                routingContext.SaveChanges();
            }
        }
    }
}
