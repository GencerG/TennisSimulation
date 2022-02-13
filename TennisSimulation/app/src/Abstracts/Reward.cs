using TennisSimulation.Models;

namespace TennisSimulation.Abstracts
{
    /// <summary>
    /// Base class for different rewards which will be granted to winner player.
    /// </summary>
    public abstract class Reward
    {
        #region Fields

        public int Id { get; set; }
        protected int WinnerPrize { get; set; }
        protected int LoserPrize { get; set; }

        #endregion Fields

        #region Constructor

        public Reward(int winnerPrize, int loserPrize)
        {
            WinnerPrize = winnerPrize;
            LoserPrize = loserPrize;
        }

        private Reward() { }

        #endregion Constructor

        #region Base Methods

        public abstract void Apply(PlayerModel winnerPlayer, PlayerModel LoserPlayer);

        #endregion Base Methods

    }
}
