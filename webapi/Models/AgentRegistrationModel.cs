using Newtonsoft.Json;

namespace webapi.Models
{

    public class AgentRegistrationModel
    {
        public AgentModel Agent { get; set; }
        public ContractModel Contract { get; set; }
        public FactionModel Faction { get; set; }
        public ShipModel Ship { get; set; }
        public string Token { get; set; }
    }
}
