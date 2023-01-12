using EIT.Model;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace EIT.Service
{
    public class ExternalRouteService
    {
        public RouteIntegrationResponse GetExternalRoute(int from, int to, int weight)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55587/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var department = new RouteIntegrationRequest() 
                { 
                    From = "test",
                    To= "test",
                    Type= "test",
                    ArrivalTime= "test",
                    Currency= "test",
                    Weight = 0,
                    Width = 0,
                    Height = 0,
                    Depth = 0,
                    Recommended=false
                };

                HttpResponseMessage response = client.PostAsJsonAsync("api/Department", department).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var res = Newtonsoft.Json.JsonConvert.DeserializeObject<RouteIntegrationResponse>(json);


                    // Get the URI of the created resource.
                    Uri returnUrl = response.Headers.Location;
                    Console.WriteLine(returnUrl);

                    return res;
                }
                return new RouteIntegrationResponse();
            }   
        }
    }
}
