using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Connect2Ocbc
{
    /// <summary>
    /// Represents a base class that contains generic API calls.
    /// </summary>
    public abstract class BaseConnect
    {
        private string _ApiURL;
        private string _token;

        /// <summary>
        /// Initializes a new instance of the BaseConnect class.
        /// </summary>
        protected BaseConnect()
        { }

        /// <summary>
        /// Initializes a new instance of the BaseConnect class with a token and API URL.
        /// </summary>
        /// <param name="token">The token provided by OCBC API.</param>
        /// <param name="apiUrl">The URL of the API.</param>
        protected BaseConnect(string token, string apiUrl)
        {
            if (!apiUrl.EndsWith("/"))
            {
                apiUrl = apiUrl + "/";
            }
            _ApiURL = apiUrl;
            _token = token;
        }

        /// <summary>
        /// Call the API with the provided HTTP method.
        /// </summary>
        /// <param name="httpmethod">The HTTP method.</param>
        /// <returns>Json object.</returns>
        protected async Task<JObject> CallAPI(HttpMethod httpmethod)
        {
            return await CallAPI(httpmethod, string.Empty, string.Empty);
        }

        /// <summary>
        /// Call the API with the provided HTTP method and parameters.
        /// </summary>
        /// <param name="httpmethod">The HTTP method.</param>
        /// <param name="APIParameters">The API Parameters.</param>
        /// <returns>Json object.</returns>
        protected async Task<JObject> CallAPI(HttpMethod httpmethod, string APIParameters)
        {
            return await CallAPI(httpmethod, APIParameters, string.Empty);
        }

        /// <summary>
        /// Call the API with the provided HTTP method and parameters and body content.
        /// </summary>
        /// <param name="httpmethod">The HTTP method.</param>
        /// <param name="APIParameters">The API Parameters.</param>
        /// <param name="content">Request body content.</param>
        /// <returns>Json object.</returns>
        protected async Task<JObject> CallAPI(HttpMethod httpmethod, string APIParameters, string content)
        {
            using (var request = new HttpRequestMessage(httpmethod, _ApiURL + APIParameters))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrWhiteSpace(content))
                {
                    request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                }
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var resp = JObject.Parse(await response.Content.ReadAsStringAsync());
                    return resp;
                }
            }
        }
    }
}
