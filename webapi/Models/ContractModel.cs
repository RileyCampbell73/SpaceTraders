namespace webapi.Models
{
    public class ContractModel
    {
        public string id { get; set; }
        public string factionSymbol { get; set; }
        public string type { get; set; }
        public Terms terms { get; set; }
        public bool accepted { get; set; }
        public bool fulfilled { get; set; }
        public DateTime expiration { get; set; }
        public DateTime deadlineToAccept { get; set; }

        public class Terms
        {
            public DateTime deadline { get; set; }
            public Payment payment { get; set; }
            public List<Deliver> deliver { get; set; }
        }

        public class Deliver
        {
            public string tradeSymbol { get; set; }
            public string destinationSymbol { get; set; }
            public int unitsRequired { get; set; }
            public int unitsFulfilled { get; set; }
        }

        public class Payment
        {
            public int onAccepted { get; set; }
            public int onFulfilled { get; set; }
        }
        
    }
}
