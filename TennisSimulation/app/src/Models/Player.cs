using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulation.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int Experience { get; set; }
        public string Hand { get; set; }
        public Skills Skills { get; set; }
    }
}
