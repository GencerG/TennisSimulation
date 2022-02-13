using System;
using TennisSimulation.Abstracts;
using TennisSimulation.Enums;
using TennisSimulation.Models;

namespace TennisSimulation.Rules
{
    /// <summary>
    /// The one who uses left hand wins.
    /// </summary>
    public class DominantHandRule : Rule
    {
        public DominantHandRule(int pointToWin, int pointToLose) : base(pointToWin, pointToLose)
        {
        }

        public override void Execute(PlayerModel player1, PlayerModel player2, string groundType)
        {
            var player1DominantHand = (DominantHand)Enum.Parse(typeof(DominantHand), player1.Hand, true);
            var player2DominantHand = (DominantHand)Enum.Parse(typeof(DominantHand), player2.Hand, true);

            player1.CurrentMatchScore += 
                player1DominantHand == DominantHand.Left 
                    ? PointToWin 
                    : PointToLose;

            player2.CurrentMatchScore += 
                player2DominantHand == DominantHand.Left 
                    ? PointToWin 
                    : PointToLose;
        }
    }
}
