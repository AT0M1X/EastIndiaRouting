using EIT.Model;
using EIT.Service;
using Microsoft.AspNetCore.Http;
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
        private readonly ServiceAccountService _serviceAccountService;
        public IntegrationController(FindRouteService findRouteService, ServiceAccountService serviceAccountService) 
        { 
            _findRouteService = findRouteService;
            _serviceAccountService = serviceAccountService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("/GetRoute", Name = nameof(GetRoute))]
        public async Task<ActionResult<RouteIntegrationResponse>> GetRoute([FromBody]RouteIntegrationRequest routeIntegrationRequest)
        {
            //conversion from city string to city id

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            if (routeIntegrationRequest.Recommended)
            {
                return NoContent();
            }

            var hasCorrelationID = Request.Headers.TryGetValue("correlationID", out var correlationID);
            var hasCollaborationID = Request.Headers.TryGetValue("collaborationID", out var collaborationID);

            if (!hasCorrelationID) return BadRequest();
            if (!hasCollaborationID) return Unauthorized();

            var serviceAccount = _serviceAccountService.GetServiceAccount(Guid.Parse(collaborationID));

            if (serviceAccount == null) return Unauthorized();

            try
            {
                var route = _findRouteService.FindRoutes(new DTOs.FindRouteDto
                {
                    From = routeIntegrationRequest.From,
                    To = routeIntegrationRequest.To,
                    Height = routeIntegrationRequest.Height,
                    Length = routeIntegrationRequest.Width,
                    Weight = routeIntegrationRequest.Weight,
                    Width = routeIntegrationRequest.Width,
                    PackageType = routeIntegrationRequest.Type,
                    SendTime = DateTime.Parse(routeIntegrationRequest.ArrivalTime),
                    CorrelationID = Guid.Parse(correlationID),
                });

                if(route != null)
                {
                    return new RouteIntegrationResponse
                    {
                        CorrelationID = correlationID,
                        Cost = route.Cost,
                        Time = route.Time
                    };
                }
                return NoContent();

            }
            catch(ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}
