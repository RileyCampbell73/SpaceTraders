using System.Drawing;
using System.Numerics;
using System.Reflection;

namespace webapi.Models
{
    public class ShipModel
    {
        public string symbol { get; set; }
        public Registration registration { get; set; }
        public Nav nav { get; set; }
        public Crew crew { get; set; }
        public Frame frame { get; set; }
        public Reactor reactor { get; set; }
        public Engine engine { get; set; }
        public Cooldown cooldown { get; set; }
        public List<Module> modules { get; set; }
        public List<Mount> mounts { get; set; }
        public Cargo cargo { get; set; }
        public Fuel fuel { get; set; }

        public class Cargo
        {
            public int capacity { get; set; }
            public int units { get; set; }
            public List<Inventory> inventory { get; set; }
        }

        public class Consumed
        {
            public int amount { get; set; }
            public DateTime timestamp { get; set; }
        }

        public class Cooldown
        {
            public string shipSymbol { get; set; }
            public int totalSeconds { get; set; }
            public int remainingSeconds { get; set; }
            public DateTime expiration { get; set; }
        }

        public class Crew
        {
            public int current { get; set; }
            public int required { get; set; }
            public int capacity { get; set; }
            public string rotation { get; set; }
            public int morale { get; set; }
            public int wages { get; set; }
        }

        public class Destination
        {
            public string symbol { get; set; }
            public string type { get; set; }
            public string systemSymbol { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        public class Engine
        {
            public string symbol { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int condition { get; set; }
            public int integrity { get; set; }
            public int speed { get; set; }
            public Requirements requirements { get; set; }
        }

        public class Frame
        {
            public string symbol { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int condition { get; set; }
            public int integrity { get; set; }
            public int moduleSlots { get; set; }
            public int mountingPoints { get; set; }
            public int fuelCapacity { get; set; }
            public Requirements requirements { get; set; }
        }

        public class Fuel
        {
            public int current { get; set; }
            public int capacity { get; set; }
            public Consumed consumed { get; set; }
        }

        public class Inventory
        {
            public string symbol { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int units { get; set; }
        }

        public class Module
        {
            public string symbol { get; set; }
            public int capacity { get; set; }
            public int range { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public Requirements requirements { get; set; }
        }

        public class Mount
        {
            public string symbol { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int strength { get; set; }
            public List<object> deposits { get; set; }
            public Requirements requirements { get; set; }
        }

        public class Nav
        {
            public string systemSymbol { get; set; }
            public string waypointSymbol { get; set; }
            public Route route { get; set; }
            public string status { get; set; }
            public string flightMode { get; set; }
        }

        public class Origin
        {
            public string symbol { get; set; }
            public string type { get; set; }
            public string systemSymbol { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        public class Reactor
        {
            public string symbol { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int condition { get; set; }
            public int integrity { get; set; }
            public int powerOutput { get; set; }
            public Requirements requirements { get; set; }
        }

        public class Registration
        {
            public string name { get; set; }
            public string factionSymbol { get; set; }
            public string role { get; set; }
        }

        public class Requirements
        {
            public int power { get; set; }
            public int crew { get; set; }
            public int slots { get; set; }
        }

        public class Route
        {
            public Destination destination { get; set; }
            public Origin origin { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrival { get; set; }
        }
    }
}
