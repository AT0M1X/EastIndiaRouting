using EIT.Interfaces;
using EIT.Model;

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
            // var topology = LoadTopology()

            // for each edge in edge
            // numofsegment = edge[Segments]
            // price = getPricePerSegment()
            // cost = number of segment * price persegment
            // UpdateTopology(edge, cost)

            // if we have both source city and destination city
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

        private void LoadTopology()
        {
            // var cities = db.getCities(); //(Id, Name, Available)
            // cities = cities.Where(x => x.Available);

            // var edges = db.getEdges(); //(Id, Source, Destination, Segments)
        }

        private void UpdateTopology()
        {
            // graph.Add(edge[Source], edge[Destination], cost)
        }

        private void GetPrice(int weight)
        {
            // load [WeightPrices](Id, Minimum, Maximum, Price)
            // make if else statement for the current month
            // make nested if else statement for the current weight
            // return the price
        }
    }
}
