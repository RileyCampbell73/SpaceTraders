namespace webapi.APICalls
{
    public class Agent_API
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;

        public Agent_API(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> GetAgentAsync()
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{Endpoint}/my/agent"),
            //    Headers =
            //    {
            //        { "Accept", "application/json" },
            //        { "Authorization", $"Bearer {Configuration["Keys:AgentToken"]}" },
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
    }
}
