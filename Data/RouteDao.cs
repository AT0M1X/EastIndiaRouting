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
        private RoutingContext _routingContext;
        public RouteDao(IServiceScopeFactory serviceScopeFactory) 
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
            }
        }

        public List<Route> GetAllRoutes()
        {
            return _routingContext.Routes.ToList();
        }

        public Route GetRoute(int id)
        {
            return _routingContext.Routes.Where(r => r.RouteID == id).FirstOrDefault();
        }

        public Route GetRoute(City origin, City destination)
        {
            return _routingContext.Routes.Where(r => r.OriginCity.CityID == origin.CityID && r.DestinationCity.CityID == destination.CityID).FirstOrDefault();
        }

        public void AddRoute(Route Route)
        {
            _routingContext.Add(Route);
            _routingContext.SaveChanges();
        }
    }
}
