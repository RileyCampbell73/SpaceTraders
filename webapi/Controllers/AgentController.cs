using Microsoft.AspNetCore.Mvc;
using webapi.APICalls;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentController : ControllerBase
    {

        private readonly IST_API_Caller Caller;

        public AgentController(IST_API_Caller caller)
        {
            Caller = caller;
        }

        [HttpGet(Name = "GetAgent")]
        public async Task<string> GetAsync()
        {
            return await Caller.ST_API_Call("my/agent");
        }
    }
}
