using System.Diagnostics.Contracts;

namespace webapi.APICalls
{
    public class Contracts_API 
    {
        public async Task<string> GetContractsAsync()
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{Endpoint}/my/contracts"),
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

        public async Task<string> AcceptContractAsync(string contractId)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri($"{Endpoint}/my/contracts/{contractId}/accept"),
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
            //}]


            return null;
        }
    }
}
