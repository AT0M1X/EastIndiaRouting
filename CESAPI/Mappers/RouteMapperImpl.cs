﻿using CESAPI.DTOs;
using CESAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace CESAPI.Mappers
{
    public class RouteMapperImpl : IRouteMapper
    {
        public RouteDto MapRouteModelToDto(Model.Route route, List<City> cities)
        {
            if (route == null)
            {
                return null;
            }
            var origin = cities.Where(city => city.CityID == route.OriginCityCityId).FirstOrDefault();
            var destination = cities.Where(city => city.CityID == route.DestinationCityCityId).FirstOrDefault();
            return new RouteDto()
            {
                Id = route.RouteID,
                From = origin.CityName,
                To = destination.CityName,
                Time = route.Segments * 12,
                Segments = route.Segments,
                FromId = route.OriginCityCityId,
                ToId = route.DestinationCityCityId
            };
        }

        public List<RouteDto> MapRouteModelsToDtos(List<Model.Route> routes, List<City> cities)
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
