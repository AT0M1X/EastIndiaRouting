using CESAPI.Context;
using CESAPI.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace CESAPI.Data
{
    public class RouteDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public RouteDao(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<Model.Route> GetAllRoutes()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Routes.ToList();
            }
        }

        public Model.Route GetRoute(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Routes.Where(r => r.RouteID == id).FirstOrDefault();
            }
        }

        public Model.Route GetRoute(int origin, int destination)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Routes.Where(r => r.OriginCityCityId == origin && r.DestinationCityCityId == destination).FirstOrDefault();
            }
        }

        public void AddRoute(Model.Route Route)
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
