using Newtonsoft.Json;
using System.Collections.Generic;
using TennisSimulation.Utils;

namespace TennisSimulation.Models
{
    public class PlayerModel
    {
        [JsonProperty(TennisSimulationUtils.Constants.JSON_PROPERTIES.ID)]
        public int Id { get; set; }

        [JsonProperty("experience")]
        public int Experience { get; set; }

        [JsonProperty("hand")]
        public string Hand { get; set; }

        [JsonProperty("skills")]
        public Skills Skills { get; set; }

        [JsonIgnore]
        public Dictionary<string, int> SkillsDictionary;

        [JsonIgnore]
        public int CurrentMatchScore { get; set; }

        [JsonIgnore]
        public bool HasPlayedMatch { get; set; }

        public void PreparePlayer()
        {
            HasPlayedMatch = false;
            CurrentMatchScore = 0;
        }

        public void PostProcess()
        {
            SkillsDictionary = new Dictionary<string, int>();
            SkillsDictionary.Add("clay", Skills.Clay);
            SkillsDictionary.Add("grass", Skills.Grass);
            SkillsDictionary.Add("hard", Skills.Hard);
        }
    }
}
