namespace EIT.Model
{
    public class Route
    {
        public int RouteID { get; set; }
        public int OriginCityCityId { get; set; }
        public int DestinationCityCityId { get; set; }
        public int Segments { get; set; }
    }
}
