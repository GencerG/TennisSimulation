using TennisSimulation.Enums;
using TennisSimulation.Interface;
using TennisSimulation.Models;

namespace TennisSimulation.Rules
{
    public class ParticipationRule : Rule
    {
        public ParticipationRule(int pointToWin, int pointToLose) : base(pointToWin, pointToLose)
        {
        }

        public override void Execute(ref PlayerModel player1, ref PlayerModel player2, string groundType)
        {
            player1.CurrentMatchScore += PointToWin;
            player2.CurrentMatchScore += PointToWin;
        }
    }
}
