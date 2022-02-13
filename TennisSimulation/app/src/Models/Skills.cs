using Newtonsoft.Json;
using TennisSimulation.Utils;

namespace TennisSimulation.Models
{
    /// <summary>
    /// Model class for player's surface skill.
    /// </summary>
    public class Skills
    {
        [JsonProperty(Constants.JSON_PROPERTIES.CLAY)]
        public int Clay { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.GRASS)]
        public int Grass { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.HARD)]
        public int Hard { get; set; }
    }
}
