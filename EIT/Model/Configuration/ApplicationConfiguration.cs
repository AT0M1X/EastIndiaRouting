namespace EIT.Model.Configuration
{
    public class ApplicationConfiguration
    {
        public string Name { get; set; }
        public bool EnableReactDevelopmentServer { get; set; }
    }

    public class ReactClientConfiguration
    {
        public string LoggingEndpoint { get; set; }
        public bool IncludeDevRoutes { get; set; }
    }
}
