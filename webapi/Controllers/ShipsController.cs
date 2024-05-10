using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using webapi.APICalls;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipsController : ControllerBase
    {

        private readonly IST_API_Caller Caller;

        public ShipsController(IST_API_Caller caller)
        {
            Caller = caller;
        }

        [HttpGet(Name = "GetShips")]
        public async Task<string> GetAsync()
        {

            //return await Caller.ST_API_Call("my/ships");

            using (HttpResponseMessage response = await Caller.ST_API_Call("my/ships", HttpMethod.Get))
            {
                //response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return await body;
            }
        }

        [HttpPost]
        [Route("navShip")]
        public async Task<string> NavShipAsync(string shipid, string waypoint)
        {

            return null;//await Caller.ST_API_Call($"my/ships/{shipid}/navigate", JsonContent.Create(new { waypointSymbol = waypoint }));
        }

        [HttpPost]
        [Route("dockShip")]
        public async Task<string> DockShipAsync(string shipid)
        {
            return null;//await Caller.ST_API_Call($"my/ships/{shipid}/dock");
        }
        
        [HttpPost]
        [Route("refuel")]
        public async Task<string> RefuelShipAsync(string shipid)
        {
            
            return null;//await Caller.ST_API_Call($"my/ships/{shipid}/refuel");
        }

        [HttpPost]
        [Route("orbit")]
        public async Task<string> OrbitShipAsync(string shipid)
        {
            return null;//await Caller.ST_API_Call($"my/ships/{shipid}/orbit");
        }

        [HttpPost]
        [Route("extract")]
        public async Task<string> ExtractResourceAsync(string shipid)
        {
            return null;//await Caller.ST_API_Call($"my/ships/{shipid}/extract");
        }

        [HttpPost]
        [Route("sell")]
        public async Task<string> SellResourceAsync(string shipid, string resource, string units)
        {
            return null;//await Caller.ST_API_Call($"my/ships/{shipid}/sell", JsonContent.Create(new { symbol = resource, units = units }));
        }
    }
}
