using CESAPI.Context;
using CESAPI.Model;

namespace CESAPI.Data
{
    public class CityDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public CityDao(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<City> GetAllCities()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Cities.ToList();
            }
        }

        public List<City> GetAvailableCities()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Cities.Where(c => c.Available).ToList();
            }
        }

        public City GetCity(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Cities.Where(c => c.CityID == id).FirstOrDefault();
            }
        }

        public City GetCity(string name)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.Cities.Where(c => c.CityName == name).FirstOrDefault();
            }
        }

        public void AddCity(City city)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                routingContext.Add(city);
                routingContext.SaveChanges();
            }
        }
    }
}
