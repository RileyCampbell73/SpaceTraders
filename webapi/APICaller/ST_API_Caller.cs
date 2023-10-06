namespace webapi.APICalls
{

    public interface IST_API_Caller
    {
        public Task<string> ST_API_Call(string method, JsonContent content = null);
    }

    public class ST_API_Caller : IST_API_Caller
    {
        private readonly IConfiguration Configuration;

        public ST_API_Caller(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> ST_API_Call(string method, JsonContent content = null)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Configuration["Keys:SpaceTradersEndpoint"]}/{method}"),
                Headers =
                {
                    { "Accept", "application/json" },
                    { "Authorization", $"Bearer {Configuration["Keys:AgentToken"]}" },
                },
                Content = content
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return await body;
            }

        }
    }
}
