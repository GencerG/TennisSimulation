using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Rewards
{
    public class ExperienceReward : Reward
    {
        public ExperienceReward(int winnerPrize, int loserPrize) : base(winnerPrize, loserPrize)
        {
        }

        public override void Apply(PlayerModel winnerPlayer, PlayerModel LoserPlayer)
        {
            winnerPlayer.Experience += WinnerPrize;
            LoserPlayer.Experience += LoserPrize;
        }
    }
}
