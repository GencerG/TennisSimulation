using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisSimulation.Utils;

namespace TennisSimulation.Models
{
    public class InputData
    {
        public InputData() { }
        public InputData(string fileName)
        {
            Console.WriteLine("reading input data from file name: " + fileName);
            var json = TennisSimulationUtils.GetJsonFromFile<InputData>(fileName);
            PlayerModels = json.PlayerModels;
            TournamentModels = json.TournamentModels;
            
            for (int i = 0; i < PlayerModels.Count; ++i)
            {
                PlayerModels[i].PostProcess();
            }
        }

        [JsonProperty("players")]
        public List<PlayerModel> PlayerModels { get; set; }
        [JsonProperty("tournaments")]
        public List<TournamentModel> TournamentModels { get; set; }
    }
}
