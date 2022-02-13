using Newtonsoft.Json;
using TennisSimulation.Utils;

namespace TennisSimulation.Models
{
    /// <summary>
    /// Model class to hold player's post-tournament data.
    /// </summary>
    public class PlayerResultModel
    {
        [JsonProperty(Constants.JSON_PROPERTIES.ORDER)]
        public int Order { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.ID)]
        public int Id { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.GAINED_EXPERIENCE)]
        public int GainedExperience { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.TOTAL_EXPERIENCE)]
        public int TotalExperience { get; set; }
    }
}
