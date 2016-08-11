using Newtonsoft.Json;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of Atm.
    /// </summary>
    public class Atm
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("landmark")]
        public string Landmark { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("noteDetails")]
        public string NoteDetails { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
