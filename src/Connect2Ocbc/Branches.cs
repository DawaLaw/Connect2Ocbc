using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connect2Ocbc
{
    /// <summary>
    /// Represents a class for retrieving a list of branches.
    /// </summary>
    public class Branches : BaseConnect
    {
        private const string APIURL = "https://api.ocbc.com:8243/branch_locator/1.0/";

        private Branches() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the Branches class with a token and API URL.
        /// </summary>
        /// <param name="token">The token provided by OCBC API.</param>
        /// <param name="apiUrl">The URL of the API.</param>
        public Branches(string token, string apiUrl = APIURL) : base(token, apiUrl)
        { }

        /// <summary>
        /// Retrieve all branches asynchronously.
        /// </summary>
        /// <returns>List of branches.</returns>
        public async Task<List<ResponseParameters.Branch>> GetAllBranchesAsync()
        {
            var resp = await CallAPI(HttpMethod.Get);
            var obj = resp.ToObject<ResponseParameters.Branches>();
            return obj.BranchArray.ToList();
        }

        /// <summary>
        /// Retrieve all branches.
        /// </summary>
        /// <returns>List of branches.</returns>
        public List<ResponseParameters.Branch> GetAllBranches()
        {
            return GetAllBranchesAsync().Result;
        }
    }
}
