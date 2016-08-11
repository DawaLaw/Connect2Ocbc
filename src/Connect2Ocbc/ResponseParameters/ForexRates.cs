using Newtonsoft.Json;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of forex rates.
    /// </summary>
    public class ForexRates
    {
        [JsonProperty("ForexRates")]
        public Rate[] RatesArray { get; set; }
    }
}
