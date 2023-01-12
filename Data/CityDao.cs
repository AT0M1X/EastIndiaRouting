using EIT.Context;
using EIT.Model;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
{
    public class CityDao
    {
        private RoutingContext _routingContext;
        public CityDao() 
        {

        }

        public List<City> GetAllCities()
        {
            var cities = new List<City>();
            cities.Add(new City { CityID = 1, Cityname = "Cityname", Available = false });
            return cities;
            //return _routingContext.Cities.ToList();
        }

        public List<City> GetAvailableCities()
        {
            var cities = new List<City>();
            cities.Add(new City { CityID = 1, Cityname = "Cityname", Available = true });
            return cities;
            //return _routingContext.Cities.Where(c => c.Available).ToList();
        }

        public City GetCity(int id)
        {
            return new City { CityID = id, Cityname = "City Name", Available = true};
        }

        public City GetCity(string name)
        {
            return new City { CityID = 1, Cityname = name, Available = true };
        }

        public void AddCity(City city)
        {
            return;
        }
    }
}
