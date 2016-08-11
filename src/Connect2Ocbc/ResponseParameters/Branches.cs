using Newtonsoft.Json;

namespace Connect2Ocbc.ResponseParameters
{
    /// <summary>
    /// Represents a class of branches.
    /// </summary>
    public class Branches
    {
        [JsonProperty("branches")]
        public Branch[] BranchArray { get; set; }
    }
}
