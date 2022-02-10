using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulation.Models
{
    public class Skills
    {
        [JsonProperty("clay")]
        public int Clay { get; set; }
        [JsonProperty("grass")]
        public int Grass { get; set; }
        [JsonProperty("hard")]
        public int Hard { get; set; }
    }
}
