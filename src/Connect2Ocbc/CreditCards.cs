using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connect2Ocbc
{
    /// <summary>
    /// Represents a class for suggesting a list of suitable credit cards.
    /// </summary>
    public class CreditCards : BaseConnect
    {
        private const string APIURL = "https://api.ocbc.com:8243/CC/1.0/";

        private CreditCards() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the CreditCards class with a token and API URL.
        /// </summary>
        /// <param name="token">The token provided by OCBC API.</param>
        /// <param name="apiUrl">The URL of the API.</param>
        public CreditCards(string token, string apiUrl = APIURL) : base(token, apiUrl)
        { }

        /// <summary>
        /// Retrieve a list of suitable credit cards based on provided keyword asynchronously.
        /// </summary>
        /// <param name="keyword">Keyword string.</param>
        /// <returns>List of credit cards.</returns>
        public async Task<List<ResponseParameters.CreditCard>> GetCreditCardSuggestionAsync(string keyword)
        {
            var resp = await CallAPI(HttpMethod.Get, keyword.Trim());
            var obj = resp.ToObject<ResponseParameters.CreditCards>();
            return obj.CreditCardArray.ToList();
        }

        /// <summary>
        /// Retrieve a list of suitable credit cards based on provided keyword.
        /// </summary>
        /// <param name="keyword">Keyword string.</param>
        /// <returns>List of credit cards.</returns>
        public List<ResponseParameters.CreditCard> GetCreditCardSuggestion(string keyword)
        {
            return GetCreditCardSuggestionAsync(keyword).Result;
        }
    }
}
