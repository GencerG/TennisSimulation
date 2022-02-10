using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Rules
{
    public class GroundTypeRule : Rule
    {
        public GroundTypeRule(int pointToWin, int pointToLose) : base(pointToWin, pointToLose)
        {
        }

        public override void Execute(ref PlayerModel player1, ref PlayerModel player2, string groundType)
        {
            if (player1.SkillsDictionary[groundType] > player2.SkillsDictionary[groundType])
            {
                player1.CurrentMatchScore += PointToWin;
                player2.CurrentMatchScore += PointToLose;
            }
            else if (player1.SkillsDictionary[groundType] < player2.SkillsDictionary[groundType])
            {
                player1.CurrentMatchScore += PointToLose;
                player2.CurrentMatchScore += PointToWin;
            }
        }
    }
}
