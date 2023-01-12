using EIT.Interfaces;
using EIT.MockModel;
using EIT.Model;
using System.Collections.Generic;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System;
using System.Linq;
using Dijkstra.NET.Graph.Simple;

namespace EIT.RoutePlanner
{
    public class RoutePlanner : IRoutePlanner
    {
        // TODO inject database and integration
        private int topology;

        public RoutePlanner()
        {
            // Don't even need this shit

        }

        public RouteResult GetRoute(int from, int to, int weight)
        {
            // Load topology
            var topology = LoadTopology(weight);

            // if we have both source city and destination city
            var ourAvailableCities = MockCity.GetAvailableId();
            if(ourAvailableCities.Contains(from) && ourAvailableCities.Contains(to)) 
            {
                ShortestPathResult result = topology.Dijkstra((uint)from, (uint)to); //result contains the shortest path
                var path = result.GetPath();
                foreach (var item in path)
                {
                    Console.WriteLine(item);
                }
            }
                // Compute Route
                // Calculate cost, time
                // Return from, to, cost, time, cost to competitors

            // if we are the source city, to external:
                // Get External route
                // for each city in our own
                // get cost + time to the destination
                // make sure it's not a loop
                // UpdateTopology(edge, cost)

                // Compute Route
                // Calculate cost, time
                // Return from, to, cost, time, cost to competitors


            // if we are the destination city:
                // break, in this case we don't 

            return new RouteResult { };
        }

        private void ComputeRoute()
        {
            // ShortestPathResult result = graph.Dijkstra(1, 2); //result contains the shortest path
            // var path = result.GetPath();
        }

        private Graph<int, string> LoadTopology(int weight)
        {
            // var cities = db.getCities(); //(Id, Name, Available)
            List<MockCity> mockCities = MockCity.GetMockCities();
            // cities = cities.Where(x => x.Available);

            // var edges = db.getEdges(); //(Id, Source, Destination, Segments)
            List<MockEdge> mockEdges = MockEdge.GetMockEdges();

            var graph = new Graph<int, string>();

            foreach (var city in mockCities)
            {
                graph.AddNode(city.Id);
            }

            foreach (var edge in mockEdges)
            {
                graph.Connect((uint)edge.Source, (uint)edge.Destination, edge.Segments * GetPrice(weight), "dummy string"); //First node has key equal 1
            }

            return graph;
        }

        private void UpdateTopology()
        {
            // graph.Add(edge[Source], edge[Destination], cost)
        }

        private int GetPrice(int weight)
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
    }
}
