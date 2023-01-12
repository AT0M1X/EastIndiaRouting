using EIT.Model;

namespace EIT.Interfaces
{
    public interface IRoutePlanner
    {
        public RouteResult GetRoute(int from, int to, int weight);
    }
}
