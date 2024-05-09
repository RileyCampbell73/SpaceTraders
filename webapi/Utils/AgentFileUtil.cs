using Microsoft.AspNetCore.Routing.Constraints;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace webapi.Utils
{
    public class AgentDetails
    {
        public string AgentID { get; set; }
        public string AccountId { get; set; }
    }

    public class AgentFileUtil
    {

        private static AgentFileUtil _instance;
        private static readonly object _lock = new object();

        private string _fileName = "AgentDetails.json";

        public static AgentFileUtil Instance
        {
            get
            {
                lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AgentFileUtil();
                        }
                        return _instance;
                    }
            }
        }


        private AgentDetails _agent = null;
        public AgentDetails Agent
        {
            get { return _agent; }
            set
            {
                _agent = value;
                SaveAgentDetails();
            }
        }

        public AgentFileUtil()
        {
            //read file and store values
            GetAgentDetails();
        }

        private void SaveAgentDetails()
        {
            // Check if file already exists. If yes, delete it.
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            using (FileStream fs = File.Create(_fileName))
            {
                Byte[] content = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(_agent));
                fs.Write(content, 0, content.Length);
            }

        }

        private void GetAgentDetails()
        {
            if (File.Exists(_fileName))
            {
                string readText = File.ReadAllText(_fileName);
                _agent = JsonConvert.DeserializeObject<AgentDetails>(readText);

            }
        }

    }
}
