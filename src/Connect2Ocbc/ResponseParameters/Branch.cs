using Newtonsoft.Json;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of branch.
    /// </summary>
    public class Branch
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("landmark")]
        public string Landmark { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
