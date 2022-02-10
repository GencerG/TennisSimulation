using Newtonsoft.Json;

namespace TennisSimulation.Models
{
    public class PlayerResultModel
    {
        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("gained_experience")]
        public int GainedExperience { get; set; }

        [JsonProperty("total_experience")]
        public int TotalExperience { get; set; }
    }
}
