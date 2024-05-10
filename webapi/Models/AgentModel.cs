using System.Numerics;

namespace webapi.Models
{
    public class AgentModel
    {
        public string accountId { get; set; }
        public string symbol { get; set; }
        public string headquarters { get; set; }
        public long credits { get; set; }
        public string startingFaction { get; set; }
        public int shipCount { get; set; }
    }
}
