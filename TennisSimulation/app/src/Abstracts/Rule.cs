using TennisSimulation.Enums;
using TennisSimulation.Models;

namespace TennisSimulation.Interface
{
    public abstract class Rule
    {
        protected int PointToLose { get; set; }
        protected int PointToWin { get; set; }

        private Rule () { }
        public Rule (int pointToWin, int pointToLose)
        {
            PointToLose = pointToLose;
            PointToWin = pointToWin;
        }

        abstract public void Execute(ref PlayerModel player1, ref PlayerModel player2, string groundType);
    }
}
