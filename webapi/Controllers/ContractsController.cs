using Microsoft.AspNetCore.Mvc;
using webapi.APICalls;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractsController
    {
        private readonly IST_API_Caller Caller;

        public ContractsController(IST_API_Caller caller)
        {
            Caller = caller;
        }

        [HttpGet(Name = "GetContracts")]
        public async Task<string> GetAsync()
        {
            return null;//await Caller.ST_API_Call("my/contracts");
        }

        [HttpPost]
        [Route("acceptContract")]
        public async Task<string> AcceptContractAsync(string contractId)
        {
            return null;//await Caller.ST_API_Call($"my/contracts/{contractId}/accept");
        }
    }
}
