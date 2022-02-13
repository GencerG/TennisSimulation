using Newtonsoft.Json;
using System.Collections.Generic;
using TennisSimulation.Utils;

namespace TennisSimulation.Models
{
    /// <summary>
    /// Model class to hold player related data.
    /// </summary>
    public class PlayerModel
    {
        [JsonProperty(Constants.JSON_PROPERTIES.ID)]
        public int Id { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.EXPERIENCE)]
        public int Experience { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.HAND)]
        public string Hand { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.SKILLS)]
        public Skills Skills { get; set; }

        [JsonIgnore]
        public Dictionary<string, int> SkillsDictionary;

        [JsonIgnore]
        public int CurrentMatchScore { get; set; }

        [JsonIgnore]
        public bool HasPlayedMatch { get; set; }

        /// <summary>
        /// Resets player's runtime data before starting next match.
        /// </summary>
        public void PreparePlayerForNextMatch()
        {
            HasPlayedMatch = false;
            CurrentMatchScore = 0;
        }

        /// <summary>
        /// Process player's skills. Maps them into a dictionary (<see cref="SkillsDictionary"/>) in order to get skill data.
        /// </summary>
        public void PostProcess()
        {
            SkillsDictionary = new Dictionary<string, int>();
            SkillsDictionary.Add(Constants.JSON_PROPERTIES.CLAY, Skills.Clay);
            SkillsDictionary.Add(Constants.JSON_PROPERTIES.GRASS, Skills.Grass);
            SkillsDictionary.Add(Constants.JSON_PROPERTIES.HARD, Skills.Hard);
        }
    }
}
