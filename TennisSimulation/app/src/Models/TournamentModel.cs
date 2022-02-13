using Newtonsoft.Json;
using TennisSimulation.Utils;

namespace TennisSimulation.Models
{
    /// <summary>
    /// Model class for different tournament types.
    /// </summary>
    public class TournamentModel
    {
        [JsonProperty(Constants.JSON_PROPERTIES.ID)]
        public int Id { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.SURFACE)]
        public string Surface { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.TYPE)]
        public string Type { get; set; }
    }
}
