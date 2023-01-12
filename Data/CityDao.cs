using EIT.Context;
using EIT.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
{
    public class CityDao
    {
        private RoutingContext _routingContext;
        public CityDao(IServiceScopeFactory serviceScopeFactory) 
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
            }
        }

        public List<City> GetAllCities()
        {
            return _routingContext.Cities.ToList();
        }

        public List<City> GetAvailableCities()
        {
            return _routingContext.Cities.Where(c => c.Available).ToList();
        }

        public City GetCity(int id)
        {
            return _routingContext.Cities.Where(c => c.CityID == id).FirstOrDefault();
        }

        public City GetCity(string name)
        {
            return _routingContext.Cities.Where(c => c.CityName == name).FirstOrDefault();
        }

        public void AddCity(City city)
        {
            _routingContext.Add(city);
            _routingContext.SaveChanges();
        }
    }
}
