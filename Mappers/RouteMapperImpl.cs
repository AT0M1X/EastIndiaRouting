using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Mappers
{
    public class RouteMapperImpl : IRouteMapper
    {
        public RouteDto MapRouteModelToDto(Route route, List<City> cities)
        {
            if (route == null)
            {
                return null;
            }
            var origin = cities.Where(city => city.CityID == route.OriginCity.CityID).FirstOrDefault();
            var destination = cities.Where(city => city.CityID == route.DestinationCity.CityID).FirstOrDefault();
            return new RouteDto()
            {
                Id = route.RouteID,
                From = route.OriginCity.CityName,
                To = route.DestinationCity.CityName,
                Time = route.Segments * 12,
                Segments = route.Segments,
                FromId=route.OriginCity.CityID,
                ToId=route.DestinationCity.CityID
            };
        }

        public List<RouteDto> MapRouteModelsToDtos(List<Route> routes, List<City> cities)
        {
            var routeDtos = new List<RouteDto>();
            foreach (var route in routes)
            {
                routeDtos.Add(MapRouteModelToDto(route, cities));
            }
            return routeDtos;
        }
    }
}
