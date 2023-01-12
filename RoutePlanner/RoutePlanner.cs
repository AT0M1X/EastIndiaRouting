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

namespace EIT.RoutePlanner
{
    public class RoutePlanner : IRoutePlanner
    {
        // TODO inject database and integration
        private int topology;

        private readonly CityService _cityService;
        private readonly RouteService _routeService;

        public RoutePlanner(RouteService routeService, CityService cityService)
        {
            _routeService = routeService;
            _cityService = cityService;
        }

        public RouteResult GetRoute(int from, int to, int weight)
        {
            // Load topology
            var topology = LoadTopology(weight);

            // if we have both source city and destination city
            var ourAvailableCities = GetAvailableId();
            
            if(ourAvailableCities.Contains(from) && ourAvailableCities.Contains(to)) 
            {
                ShortestPathResult result = topology.Dijkstra((uint)from, (uint)to); //result contains the shortest path
                var path = result.GetPath().ToList(); // a list of integer starting from source, to destination
                var cost = GetRouteCost(path, weight);
                var time = GetRouteTravelTime(path);
                return new RouteResult { 
                    From= from,
                    To= to,
                    Cost= cost,
                    Time= time,
                    CostToCompetitors =0
                };
            }
           

            // if we are the source city, to external:
            if (ourAvailableCities.Contains(from))
            {
                // Get External route
                // for each city in our own
                // get cost + time to the destination
                // UpdateTopology(edge, cost)
                // Compute Route
                // Calculate cost, time
                // Return from, to, cost, time, cost to competitors
            }
            if(ourAvailableCities.Contains(to)) // give error
            {
                
            }

            // if we are the destination city:
            // break, in this case we don't 

            return new RouteResult { };
        }

        public IEnumerable<uint> GetRoutetwo(int from, int to, int weight)
        {
            // Load topology
            var topology = LoadTopology(weight);

            // if we have both source city and destination city
            var ourAvailableCities = MockCity.GetAvailableId();
            Console.WriteLine(ourAvailableCities);
            if (ourAvailableCities.Contains(from) && ourAvailableCities.Contains(to))
            {
                ShortestPathResult result = topology.Dijkstra((uint)from, (uint)to); //result contains the shortest path
                var path = result.GetPath().ToList();
                return path;
            }
            else
            {
                return new List<uint>();
            }
        }

        private Graph<int, string> LoadTopology(int weight)
        {
            // var cities = db.getCities(); //(Id, Name, Available)
            //List<MockCity> mockCities = MockCity.GetMockCities();
            var cities = _cityService.GetCities();
            // cities = cities.Where(x => x.Available);

            // var edges = db.getEdges(); //(Id, Source, Destination, Segments)
            //List<MockEdge> mockEdges = MockEdge.GetMockEdges();
            var edges = _routeService.GetInternalRoutes();

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

        private void UpdateTopology()
        {
            // graph.Add(edge[Source], edge[Destination], cost)
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

        private int GetRouteCost(List<uint> path, int weight)
        {
            int routeCost = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                MockEdge edge = MockEdge.GetMockEdge(Convert.ToInt32(path[i]), Convert.ToInt32(path[i + 1]) );
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
    }
}
