namespace EIT.Model
{
    public class Route
    {
        public int RouteID { get; set; }
        public City OriginCity { get; set; }
        public City DestinationCity { get; set; }
        public int Segments { get; set; }
    }
}
