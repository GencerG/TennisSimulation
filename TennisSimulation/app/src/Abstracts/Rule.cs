using TennisSimulation.Models;

namespace TennisSimulation.Abstracts
{
    public abstract class Rule
    {
        #region Fields

        protected int PointToLose { get; set; }
        protected int PointToWin { get; set; }

        #endregion Fields

        #region Constructor

        private Rule() { }
        public Rule(int pointToWin, int pointToLose)
        {
            PointToLose = pointToLose;
            PointToWin = pointToWin;
        }

        #endregion Constructor

        #region Base Methods

        abstract public void Execute(ref PlayerModel player1, ref PlayerModel player2, string groundType);

        #endregion Base Methods
    }
}
