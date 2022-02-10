using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Rewards
{
    public class LeagueMatchReward : Reward
    {
        public LeagueMatchReward(int winnerPrize, int loserPrize) : base(winnerPrize, loserPrize)
        {
        }

        public override void Execute(ref PlayerModel winnerPlayer, ref PlayerModel LoserPlayer)
        {
            winnerPlayer.Experience += WinnerPrize;
            LoserPlayer.Experience += LoserPrize;
        }
    }
}
