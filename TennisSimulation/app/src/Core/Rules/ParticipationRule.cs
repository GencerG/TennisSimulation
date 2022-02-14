using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Rules
{
    /// <summary>
    /// Both player wins by attending a match.
    /// </summary>
    public class ParticipationRule : Rule
    {
        public ParticipationRule(int pointToWin, int pointToLose) : base(pointToWin, pointToLose)
        {
        }

        public override void Execute(PlayerModel player1, PlayerModel player2, string groundType)
        {
            player1.CurrentMatchScore += PointToWin;
            player2.CurrentMatchScore += PointToWin;
        }
    }
}
