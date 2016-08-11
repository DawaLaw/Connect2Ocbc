using Newtonsoft.Json;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of credit cards.
    /// </summary>
    public class CreditCards
    {
        [JsonProperty("CCSuggest")]
        public CreditCard[] CreditCardArray { get; set; }
    }
}
