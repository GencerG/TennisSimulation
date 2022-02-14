using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Rules
{
    /// <summary>
    /// The one with the highest ground type skill wins.
    /// </summary>
    public class GroundTypeRule : Rule
    {
        public GroundTypeRule(int pointToWin, int pointToLose) : base(pointToWin, pointToLose)
        {
        }

        public override void Execute(PlayerModel player1, PlayerModel player2, string groundType)
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
