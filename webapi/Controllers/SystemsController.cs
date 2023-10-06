using Microsoft.AspNetCore.Mvc;
using webapi.APICalls;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemsController : ControllerBase
    {
        [HttpGet(Name = "GetSystems")]
        public async Task<string> GetAsync()
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{Endpoint}/systems"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    },
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}

            return null;


        }

        [HttpGet]
        [Route("waypoints")]
        public async Task<string> GetSystemWaypointsAsync(string system)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{Endpoint}/systems/{system}/waypoints"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    },
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}

            return null;
        }

        [HttpGet]
        [Route("waypoint")]
        public async Task<string> GetWaypointAsync(string waypointId)
        {
            //string system = waypoint.Substring(0, waypoint.LastIndexOf('-'));

            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{Endpoint}/systems/{system}/waypoints/{waypoint}"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    },
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}
            return null;
        }

        [HttpGet]
        [Route("shipyard")]
        public async Task<string> GetPurchasableShipsAsync(string waypoint)
        {
            //string system = waypoint.Substring(0, waypoint.LastIndexOf('-'));

            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{Endpoint}/systems/{system}/waypoints/{waypoint}/shipyard"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    },
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}
            return null;
        }

        [HttpPost]
        [Route("purchaseShip")]
        public async Task<string> PurchaseShipAsync(string shiptype, string waypoint)
        {
            //string system = waypoint.Substring(0, waypoint.LastIndexOf('-'));

            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/ships"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    },
            //    Content = JsonContent.Create(new { shipType = ship, waypointSymbol = waypoint })
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}
            return null;
        }
    }
}
