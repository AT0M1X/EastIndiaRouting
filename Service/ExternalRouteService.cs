using EIT.Model;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using EIT.DTOs;
using EIT.Interfaces;

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
                    Depth = findRouteDto.Lenght,
                    Recommended = findRouteDto.Recommended
                };

                HttpResponseMessage response = client.PostAsJsonAsync("GetRoute", req).Result;

                if (response.IsSuccessStatusCode)
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
