namespace webapi.APICalls
{
    public class Ships_API
    {
        public async Task<string> GetShipsAsync()
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{Endpoint}/my/ships"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    }
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

        public async Task<string> NavShipAsync(string shipId, string Waypoint)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/ships/{shipId}/navigate"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    },
            //    Content = JsonContent.Create(new { waypointSymbol = Waypoint })
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

        public async Task<string> DockShipAsync(string shipId)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/ships/{shipId}/dock"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    }
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

        public async Task<string> RefuelShipAsync(string shipId)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/ships/{shipId}/refuel"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    }
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

        public async Task<string> OrbitShipAsync(string shipId)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/ships/{shipId}/orbit"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    }
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

        public async Task<string> ExtractResourceAsync(string shipId)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/ships/{shipId}/extract"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    }
            //    //will need body later when waypoint has multiple resources
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    //response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}

            return null;
        }

        public async Task<string> SellResourceAsync(string shipId, string resource, string units)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/ships/{shipId}/sell"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {AgentToken}" },
            //    },
            //    Content = JsonContent.Create(new { symbol = resource, units = units })
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    //response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}

            return null;
        }
    }
}
