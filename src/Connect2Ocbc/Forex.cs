using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connect2Ocbc
{
    /// <summary>
    /// Represents a class for retrieving Forex exchange.
    /// </summary>
    public class Forex : BaseConnect
    {
        private const string APIURL = "https://api.ocbc.com:8243/Forex/1.0/";

        private Forex() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the Forex class with a token and API URL.
        /// </summary>
        /// <param name="token">The token provided by OCBC API.</param>
        /// <param name="apiUrl">The URL of the API.</param>
        public Forex(string token, string apiUrl = APIURL) : base(token, apiUrl)
        { }

        /// <summary>
        /// Retrieve all forex rates asynchronously.
        /// </summary>
        /// <returns>List of forex rates.</returns>
        public async Task<List<ResponseParameters.Rate>> GetAllRatesAsync()
        {
            var resp = await CallAPI(HttpMethod.Get);
            var obj = resp.ToObject<ResponseParameters.ForexRates>();
            return obj.RatesArray.ToList();
        }

        /// <summary>
        /// Retrieve all forex rates.
        /// </summary>
        /// <returns>List of forex rates.</returns>
        public List<ResponseParameters.Rate> GetAllRates()
        {
            return GetAllRatesAsync().Result;
        }
    }
}
