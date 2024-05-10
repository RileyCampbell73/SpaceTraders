using Newtonsoft.Json.Linq;

namespace webapi.Utils
{
    public static class Helpers
    {
        public static string getJsonString(string content)
        {
            //all calls to the api return in a 'data' object. This is to 
            return JObject.Parse(content).SelectToken("data").ToString();
        }

    }
}
