using System.Net.Http.Headers;
using webapi.Utils;

namespace webapi.APICalls
{

    public interface IST_API_Caller
    {
        public Task<HttpResponseMessage> ST_API_Call(string action, HttpMethod method, JsonContent content = null, bool authorizationRequired = true);
    }

    public class ST_API_Caller : IST_API_Caller
    {
        private readonly IConfiguration Configuration;

        public ST_API_Caller(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<HttpResponseMessage> ST_API_Call(string action, HttpMethod method, JsonContent content = null, bool authorizationRequired = true)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{Configuration["Keys:SpaceTradersEndpoint"]}/{action}"),
                Content = content
            };

            request.Headers.Add("Accept", "application/json");

            if (authorizationRequired)
                request.Headers.Add("Authorization", $"Bearer {AgentFileUtil.Instance.Agent.AgentID}");

            return await client.SendAsync(request);
        }
    }
}
