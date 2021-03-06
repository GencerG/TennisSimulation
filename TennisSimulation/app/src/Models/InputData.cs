using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TennisSimulation.Utils;

namespace TennisSimulation.Models
{
    /// <summary>
    /// Helps to read input data from json file and stores them.
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// Model class to hold all players and tournaments from given input json
        /// </summary>
        public InputData() { }
        public InputData(string fileName)
        {
            Console.WriteLine($"-> Reading input data from file name: {fileName}");
            var json = TennisSimulationUtils.GetObjectFromJsonFile<InputData>(fileName);
            PlayerModels = json.PlayerModels;
            TournamentModels = json.TournamentModels;
            
            for (int i = 0; i < PlayerModels.Count; ++i)
            {
                PlayerModels[i].PostProcess();
            }
        }

        [JsonProperty(Constants.JSON_PROPERTIES.PLAYERS)]
        public List<PlayerModel> PlayerModels { get; set; }

        [JsonProperty(Constants.JSON_PROPERTIES.TOURNAMENTS)]
        public List<TournamentModel> TournamentModels { get; set; }
    }
}
