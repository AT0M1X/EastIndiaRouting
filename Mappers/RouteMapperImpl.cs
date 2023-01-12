using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public class RouteMapperImpl : IRouteMapper
    {
        public RouteDto MapRouteModelToDto(Route route)
        {
            if (route == null)
            {
                return null;
            }
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

        public List<RouteDto> MapRouteModelsToDtos(List<Route> routes)
        {
            var routeDtos = new List<RouteDto>();
            foreach (var route in routes)
            {
                routeDtos.Add(MapRouteModelToDto(route));
            }
            return routeDtos;
        }
    }
}
