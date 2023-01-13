using CESAPI.Model;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using CESAPI.DTOs;
using CESAPI.Interfaces;
using Azure.Core;

namespace CESAPI.Service
{
    public class ExternalRouteService : IExternalRouteService
    {
        public RouteIntegrationResponse GetExternalRoute(FindRouteDto findRouteDto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://wa-tl-dk1.azurewebsites.net/api/GetRoute");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("correlationID", Guid.NewGuid().ToString());
                client.DefaultRequestHeaders.Add("collaborationID", "f87c9339-ff39-4225-be09-fca238a03ede");
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

                    return res;
                }
                return null;
            }
        }
    }
}
