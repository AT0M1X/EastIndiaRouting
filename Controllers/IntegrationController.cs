using EIT.Model;
using EIT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EIT.Controllers
{
    [ApiController]
    [Route("[api]")]
    public class IntegrationController : Controller
    {
        private readonly FindRouteService _findRouteService;
        public IntegrationController(FindRouteService findRouteService) 
        { 
            _findRouteService = findRouteService;
        }

        [HttpPost("/GetRoute", Name = nameof(GetRoute))]
        public async Task<ActionResult<RouteIntegrationResponse>> GetRoute([FromBody]RouteIntegrationRequest routeIntegrationRequest)
        {
            //conversion from city string to city id

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            var route = _findRouteService.FindRoutes(new DTOs.FindRouteDto
            {
                From= routeIntegrationRequest.From,
                To= routeIntegrationRequest.To,
                Height= routeIntegrationRequest.Height,
                Lenght= routeIntegrationRequest.Width,
                Weight=routeIntegrationRequest.Weight,
                Width= routeIntegrationRequest.Width,
                PackageType=routeIntegrationRequest.Type,
                SendTime= DateTime.Parse(routeIntegrationRequest.ArrivalTime),

            });
            
            return new RouteIntegrationResponse
            {
                CorrelationID = Guid.NewGuid().ToString(),
                Cost = route.Cost,
                Time = route.Time
            };
        }
    }
}
