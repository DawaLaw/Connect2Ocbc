using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connect2Ocbc
{
    /// <summary>
    /// Represents a class for retrieving a list of ATMs.
    /// </summary>
    public class Atms : BaseConnect
    {
        private const string APIURL = "https://api.ocbc.com:8243/atm_locator/1.0/";

        private Atms() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the Atms class with a token and API URL.
        /// </summary>
        /// <param name="token">The token provided by OCBC API.</param>
        /// <param name="apiUrl">The URL of the API.</param>
        public Atms(string token, string apiUrl = APIURL) : base(token, apiUrl)
        { }

        /// <summary>
        /// Retrieve all ATMs asynchronously.
        /// </summary>
        /// <returns>List of ATMs.</returns>
        public async Task<List<ResponseParameters.Atm>> GetAllAtmsAsync()
        {
            var resp = await CallAPI(HttpMethod.Get);
            var obj = resp.ToObject<ResponseParameters.Atms>();
            return obj.AtmArray.ToList();
        }

        /// <summary>
        /// Retrieve all ATMs.
        /// </summary>
        /// <returns>List of ATMs.</returns>
        public List<ResponseParameters.Atm> GetAllAtms()
        {
            return GetAllAtmsAsync().Result;
        }
    }
}
