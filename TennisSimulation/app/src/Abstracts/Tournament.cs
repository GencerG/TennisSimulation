using System;
using System.Collections.Generic;
using TennisSimulation.Models;

namespace TennisSimulation.Abstracts
{
    /// <summary>
    /// Base class for different Tournaments types. Stores and applies rules and plays matches.
    /// </summary>
    public abstract class Tournament
    {
        #region Fields

        protected TournamentModel TournamentModel;
        protected List<Rule> Rules = new List<Rule>();
        protected List<Reward> MatchRewards = new List<Reward>();

        #endregion Fields

        #region Constructor

        public Tournament(TournamentModel tournamentModel)
        {
            if (tournamentModel == null)
                throw new ArgumentNullException($"Given Tournament model is null");

            TournamentModel = tournamentModel;
        }

        // Forcing to apply model in constructor to this class.
        private Tournament() { }

        #endregion Constructor


        #region Builder

        public Tournament SetRule(Rule rule)
        {
            Rules.Add(rule);
            return this;
        }

        public Tournament SetMatchReward(Reward reward)
        {
            MatchRewards.Add(reward);
            return this;
        }

        #endregion Builder

        #region Base Methods

        public abstract void StartTournament(List<PlayerModel> participants);

        /// <summary>
        /// Faces off two given players by the applied rules of current torunament.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="randomGenerator"></param>
        /// <returns>Returns <see cref="PlayerModel"/> array, winner is always at index zero, loser is at one</returns>
        protected PlayerModel[] PlayMatch(PlayerModel player1, PlayerModel player2, Random randomGenerator)
        {
            // Facing off players by the rules.
            for (int i = 0; i < Rules.Count; ++i)
            {
                Rules[i].Execute(player1, player2, TournamentModel.Surface);
            }

            // Getting a random value between zero and sum of player scores.
            var randomValue = randomGenerator.Next(0, player1.CurrentMatchScore + player2.CurrentMatchScore);
            var hasPlayer1Won = randomValue < player1.CurrentMatchScore;

            var winnerPlayer = hasPlayer1Won ? player1 : player2;
            var loserPlayer = hasPlayer1Won ? player2 : player1;

            // Resetting relative player data before starting next match.
            player1.PreparePlayerForNextMatch();
            player2.PreparePlayerForNextMatch();

            // Giving players their rewards
            for (int i = 0; i < MatchRewards.Count; ++i)
            {
                MatchRewards[i].Apply(winnerPlayer, loserPlayer);
            }

            return new PlayerModel[2] { winnerPlayer, loserPlayer };
        }

        #endregion Base Methods
    }
}
