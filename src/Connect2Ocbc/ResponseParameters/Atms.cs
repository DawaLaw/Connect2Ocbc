using Newtonsoft.Json;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of Atms.
    /// </summary>
    public class Atms
    {
        [JsonProperty("ATMS")]
        public Atm[] AtmArray { get; set; }
    }
}
