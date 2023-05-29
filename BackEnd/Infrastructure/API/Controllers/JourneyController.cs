using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPathFinder.Core.Domain;

namespace TravelPathFinder.Backend.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyRoute _journeyRoute;

        public JourneyController(IJourneyRoute journeyRoute)
        {
            _journeyRoute = journeyRoute;
        }

        [HttpGet("calculate-routes")]
        public async Task<IActionResult> CalculateAllRoutes([FromQuery] string origin, [FromQuery] string destination)
        {
            var routes = await _journeyRoute.CalculateAllRoutes(origin, destination);
            return Ok(routes);
        }
    }
}
