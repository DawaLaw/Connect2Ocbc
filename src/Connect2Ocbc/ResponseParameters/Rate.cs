using Newtonsoft.Json;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of forex rate.
    /// </summary>
    public class Rate
    {
        [JsonProperty("bankBuyingRateTT")]
        public float BankBuyingRateTT { get; set; }

        [JsonProperty("bankSellingRate")]
        public float BankSellingRate { get; set; }

        [JsonProperty("fromCurrency")]
        public string FromCurrency { get; set; }

        [JsonProperty("toCurrency")]
        public string ToCurrency { get; set; }

        [JsonProperty("unit")]
        public long Unit { get; set; }
    }
}
