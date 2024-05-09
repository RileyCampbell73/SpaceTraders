using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using webapi.APICalls;
using webapi.Utils;

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

        [HttpPost]
        [Route("register")]
        public async Task<string> createAgent(string faction, string name, string email)
        {
            using (HttpResponseMessage response = await Caller.ST_API_Call_POST("register", JsonContent.Create(new { faction = faction, symbol = name, email = email }), false))
            {
                var body = await response.Content.ReadAsStringAsync();

                //capture the API token and put it into secret config
                //return something to signify success 
                //return agent data to populate stuff
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                   
                }
                var jsonData = JsonConvert.DeserializeObject(body) as JObject;
                string newAgentId = jsonData["data"]["token"].Value<string>();
                string accountId = jsonData["data"]["agent"]["accountId"].Value<string>();

                //Need to store this info. Where?
                //DB = overkill
                //file? & gitignore it

                AgentFileUtil.Instance.Agent = new AgentDetails()
                {
                    AgentID = newAgentId,
                    AccountId = accountId
                };

                return body;
            }
               
        }

        [HttpGet(Name = "GetAgent")]
        public async Task<string> GetAsync()
        {

            //check the agent until first? If user has an agent it should be in the file. 
            //\error could still happen if the agent has expired
                //is that stored anywhere? Might be good to remember

            using (HttpResponseMessage response = await Caller.ST_API_Call("my/agent"))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return body;
                }
                else
                {
                    var jsonData = JsonConvert.DeserializeObject(body) as JObject;

                    string ErrorMessage = jsonData["error"]["message"].Value<string>();

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && ErrorMessage.ToLower().Contains("failed to parse token"))
                    {
                        return JsonConvert.SerializeObject(
                            JObject.FromObject(new
                            { 
                                ResponseCode = 2,
                                Message = "Agent Token Failure. Please create a new one."
                            }
                        ));
                    }
                    else
                    {
                        return JsonConvert.SerializeObject(
                            JObject.FromObject(new
                            {
                                ResponseCode = 99,
                                Message = "Unknown Error Occured",
                                HTMLStatusCode = (int)response.StatusCode,
                                Body = body
                            }
                        ));
                    }
                }
            }
        }
    }
}
