using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisSimulation.Models;

namespace TennisSimulation.Abstracts
{
    public abstract class Reward
    {
        protected int WinnerPrize { get; set; }
        protected int LoserPrize { get; set; }

        public Reward(int winnerPrize, int loserPrize)
        {
            WinnerPrize = winnerPrize;
            LoserPrize = loserPrize;
        }

        private Reward() { }

        public abstract void Execute(ref PlayerModel winnerPlayer, ref PlayerModel LoserPlayer);

    }
}
