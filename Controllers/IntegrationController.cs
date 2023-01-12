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

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return new RouteIntegrationResponse
            {
                CorrelationID = Guid.NewGuid().ToString(),
                Cost = 100,
                Time = 100
            };
        }
    }
}
