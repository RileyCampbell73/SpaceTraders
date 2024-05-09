using System.Net.Http.Headers;
using webapi.Utils;

namespace webapi.APICalls
{

    public interface IST_API_Caller
    {
        public Task<HttpResponseMessage> ST_API_Call(string action, JsonContent content = null);
        public Task<HttpResponseMessage> ST_API_Call_POST(string action, JsonContent content = null, bool Authorization = true);//I hate this. fix it

    }

    public class ST_API_Caller : IST_API_Caller
    {
        private readonly IConfiguration Configuration;

        public ST_API_Caller(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<HttpResponseMessage> ST_API_Call(string action, JsonContent content = null)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Configuration["Keys:SpaceTradersEndpoint"]}/{action}"),
                Headers =
                {
                    { "Accept", "application/json" },
                    { "Authorization", $"Bearer {AgentFileUtil.Instance.Agent.AgentID}" },
                },
                Content = content
            };

            return await client.SendAsync(request);
            //using (HttpResponseMessage response = await client.SendAsync(request))
            //{
            //    //response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}
        }

        public async Task<HttpResponseMessage> ST_API_Call_POST(string action, JsonContent content = null, bool Authorization = true)
        {

            var client = new HttpClient();
            HttpRequestMessage request = null;
            if (Authorization)
            {
                request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{Configuration["Keys:SpaceTradersEndpoint"]}/{action}"),
                    Headers =
                    {
                        { "Accept", "application/json" },
                        { "Authorization", $"Bearer {AgentFileUtil.Instance.Agent.AgentID}" },
                    },
                    Content = content
                };
            }
            else
            {

                request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{Configuration["Keys:SpaceTradersEndpoint"]}/{action}"),
                    Headers =
                    {
                        { "Accept", "application/json" }
                    },
                    Content = content
                };

            }

            return await client.SendAsync(request);
            //using (HttpResponseMessage response = await client.SendAsync(request))
            //{
            //    //response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    return await body;
            //}
        }
    }
}
