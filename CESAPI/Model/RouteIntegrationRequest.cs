namespace CESAPI.Model
{
    public class RouteIntegrationRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public string ArrivalTime { get; set; }
        public string Currency {
            get; set;
        }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int Depth { get; set; }
        public bool Recommended { get; set; }
    }
}
