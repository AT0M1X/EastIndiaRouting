using EIT.Model;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using EIT.DTOs;
using EIT.Interfaces;
using Azure.Core;

namespace EIT.Service
{
    public class ExternalRouteService : IExternalRouteService
    {
        public RouteIntegrationResponse GetExternalRoute(FindRouteDto findRouteDto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6004/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("correlationID", Guid.NewGuid().ToString());
                client.DefaultRequestHeaders.Add("collaborationID", "6b1af4a5-dd96-4f61-8631-69aabd684b2c");
                var req = new RouteIntegrationRequest() 
                {
                    From = findRouteDto.From,
                    To = findRouteDto.To,
                    Type = findRouteDto.PackageType,
                    ArrivalTime = findRouteDto.SendTime.ToString(),
                    Currency = findRouteDto.Currency,
                    Weight = findRouteDto.Weight,
                    Width = findRouteDto.Width,
                    Height = findRouteDto.Height,
                    Depth = findRouteDto.Length,
                    Recommended = findRouteDto.Recommended
                };

                HttpResponseMessage response = client.PostAsJsonAsync("GetRoute", req).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var res = Newtonsoft.Json.JsonConvert.DeserializeObject<RouteIntegrationResponse>(json);


                    // Get the URI of the created resource.
                    Uri returnUrl = response.Headers.Location;
                    Console.WriteLine(returnUrl);

                    return res;
                }
                return null;
            }   
        }
    }
}
