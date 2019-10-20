using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Travel_Planner.Controllers
{
    [ApiController]
    [Route("api/travelPlan")]
    public class TravelPlannerController : ControllerBase
    {
        Plan[] plan;
        private static readonly HttpClient client = new HttpClient() { };
        private static TravelPlannerLibrary.TravelPlannerLibrary library = new TravelPlannerLibrary.TravelPlannerLibrary();

        public TravelPlannerController() { }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string from, [FromQuery] string to, [FromQuery] string start)
        {
            HttpResponseMessage response = await client.GetAsync($"https://cddataexchange.blob.core.windows.net/data-exchange/htl-homework/travelPlan.json");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            plan = JsonSerializer.Deserialize<Plan[]>(responseBody);
            var route = library.FindRoute(from, to, start, plan);
            if(route != null)
            {
                return Ok(route);
            }
            return NotFound();

        }
    }
}
