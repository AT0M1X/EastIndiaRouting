using EIT.Interfaces;
using EIT.MockModel;
using EIT.Model;
using System.Collections.Generic;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System;
using System.Linq;
using Dijkstra.NET.Graph.Simple;
using EIT.Service;
using EIT.DTOs;
using Microsoft.Extensions.Hosting;

namespace EIT.RoutePlanner
{
    public class RoutePlanner : IRoutePlanner
    {
        private readonly CityService _cityService;
        private readonly RouteService _routeService;
        private readonly IExternalRouteService _externalRouteService;

        public RoutePlanner(RouteService routeService, CityService cityService, IExternalRouteService externalRouteService)
        {
            _routeService = routeService;
            _cityService = cityService;
            _externalRouteService = externalRouteService;
        }

        public RouteResult GetRoute(int from, int to, FindRouteDto findRouteDto)
        {
            // Load topology
            var cities = _cityService.GetCities();
            var edges = _routeService.GetInternalRoutes();

            var topology = LoadTopology(cities, edges, findRouteDto.Weight);

            // if we have both source city and destination city
            var ourAvailableCities = GetAvailableId();
            
            if(ourAvailableCities.Contains(from) && ourAvailableCities.Contains(to)) 
            {
                ShortestPathResult result = topology.Dijkstra((uint)from, (uint)to); //result contains the shortest path
                var path = result.GetPath().ToList(); // a list of integer starting from source, to destination
                if(path != null)
                {
                    var cost = GetRouteCost(path, edges, findRouteDto.Weight);
                    var time = GetRouteTravelTime(path);
                    return new RouteResult
                    {
                        From = from,
                        To = to,
                        Cost = cost,
                        Time = time,
                        CostToCompetitors = 0
                    };
                }
                return null;
            }
           

            // if we are the source city, to external:
            if (ourAvailableCities.Contains(from))
            {
                bool newNodeAdded = false;
                foreach (var cityId in ourAvailableCities)
                {
                    var city = _cityService.GetCity(cityId);
                    var routeDto = new FindRouteDto
                    {
                        From = city.Name,
                        To = findRouteDto.To,
                        Height = findRouteDto.Height,
                        Length = findRouteDto.Length,
                        Weight = findRouteDto.Weight,
                        Width = findRouteDto.Width,
                        PackageType = findRouteDto.PackageType,
                        SendTime = findRouteDto.SendTime,
                        Currency= findRouteDto.Currency,
                        Recommended= findRouteDto.Recommended
                    };
                    var externalRouteResponse = _externalRouteService.GetExternalRoute(routeDto);

                    if(externalRouteResponse == null)
                    {
                        continue;
                    }
                    else
                    {
                        if(!newNodeAdded)
                        {
                            topology.AddNode(to);
                            newNodeAdded = true;
                        }
                        topology.Connect((uint)cityId, (uint)to, externalRouteResponse.Cost, "dummy string");
                        topology.Connect((uint)to, (uint)cityId, externalRouteResponse.Cost, "dummy string");
                        edges.Add(new RouteDto
                        {
                            FromId = cityId,
                            ToId = to,
                            Time = externalRouteResponse.Time
                        });
                        edges.Add(new RouteDto
                        {
                            FromId = to,
                            ToId = cityId,
                            Time = externalRouteResponse.Time
                        });
                    }
                }

                ShortestPathResult result = topology.Dijkstra((uint)from, (uint)to); //result contains the shortest path
                var path = result.GetPath().ToList(); // a list of integer starting from source, to destination
                var cost = GetRouteCost(path, edges, findRouteDto.Weight);
                var time = GetRouteTravelTime(path);
                return new RouteResult
                {
                    From = from,
                    To = to,
                    Cost = cost,
                    Time = time,
                    CostToCompetitors = 0
                };

            }
            if(ourAvailableCities.Contains(to)) // give error
            {
                return null;
            }

            // if we are the destination city:
            // break, in this case we don't 

            return null;
        }

        private Graph<int, string> LoadTopology(List<CityDto> cities, List<RouteDto> edges, int weight)
        {
            var graph = new Graph<int, string>();

            foreach (var city in cities)
            {
                graph.AddNode(city.Id);
            }

            foreach (var edge in edges)
            {
                graph.Connect((uint)edge.FromId, (uint)edge.ToId, edge.Segments * GetSeasonalPrice(weight), "dummy string"); //First node has key equal 1
            }

            return graph;
        }

        private int GetSeasonalPrice(int weight)
        {
            // load [WeightPrices](Id, Minimum, Maximum, Price)
            var mockWeightPrices = MockWeightPrices.GetMockWeightPrices();
            // make if else statement for the current month
            // make nested if else statement for the current weight
            DateTime dt = DateTime.Now;
            var currentMonth = dt.Month; //integer between 1 and 12.
            if(currentMonth >= 5 && currentMonth <= 10) //May-Oct
            {
                if(weight < 10) // kilogram
                {
                    var price = mockWeightPrices.Where(x => x.Id == 2).Single();
                    return price.Price;
                }
                else if(weight < 50)
                {
                    var price = mockWeightPrices.Where(x => x.Id == 4).Single();
                    return price.Price;
                }
                else
                {
                    var price = mockWeightPrices.Where(x => x.Id == 6).Single();
                    return price.Price;
                }
            }
            else //Nov-April
            {
                if (weight < 10) // kilogram
                {
                    var price = mockWeightPrices.Where(x => x.Id == 1).Single();
                    return price.Price;
                }
                else if (weight < 50)
                {
                    var price = mockWeightPrices.Where(x => x.Id == 3).Single();
                    return price.Price;
                }
                else
                {
                    var price = mockWeightPrices.Where(x => x.Id == 5).Single();
                    return price.Price;
                }
            }
            // return the price
        }

        private int GetRouteCost(List<uint> path, List<RouteDto> edges, int weight)
        {
            int routeCost = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                var edge = GetEdge(edges, Convert.ToInt32(path[i]), Convert.ToInt32(path[i + 1]));
                routeCost += edge.Segments * GetSeasonalPrice(weight);
            }
            return routeCost;
        }

        private int GetRouteTravelTime(List<uint> path)
        {
            //TODO: implement waiting time
            int routeTravelTime = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                MockEdge edge = MockEdge.GetMockEdge(Convert.ToInt32(path[i]), Convert.ToInt32(path[i + 1]));
                routeTravelTime += edge.Segments * 12; // 12 hours for each completed segment
            }
            return routeTravelTime;
        }

        public List<int> GetAvailableId()
        {
            var setCities = new HashSet<int>();
            var edges = _routeService.GetInternalRoutes();
            foreach (var edge in edges)
            {
                setCities.Add(edge.FromId);
                setCities.Add(edge.ToId);
            }
            return setCities.ToList();
        }

        private RouteDto GetEdge(List<RouteDto> edges, int from, int to)
        {
            return edges.Where(x => x.FromId == from && x.ToId == to).FirstOrDefault();
        }
    }
}
