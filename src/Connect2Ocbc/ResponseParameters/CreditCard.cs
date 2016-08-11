using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of credit card.
    /// </summary>
    public class CreditCard
    {
        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }

        public List<string> KeywordList
        {
            get {
                if (!string.IsNullOrWhiteSpace(Keywords))
                {
                    return Keywords.Split(',').Select(p => p.Trim()).ToList();
                }
                return null;
            }
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("productURL")]
        public string ProductURL { get; set; }

        [JsonProperty("TagLine")]
        public string TagLine { get; set; }
    }
}
