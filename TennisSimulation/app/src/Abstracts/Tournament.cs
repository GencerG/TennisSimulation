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
            TournamentModel = tournamentModel;
        }

        // Forcing to apply model in constructor to this class.
        private Tournament() { }

        #endregion Constructor


        #region Builder

        public Tournament ApplyRule(Rule rule)
        {
            Rules.Add(rule);
            return this;
        }

        public Tournament ApplyMatchReward(Reward reward)
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
            Console.WriteLine($"Id {player1.Id} is playing against Id {player2.Id} in a {TournamentModel.Type.ToUpperInvariant()} match");

            // Facing off players by the rules.
            for (int i = 0; i < Rules.Count; ++i)
            {
                Rules[i].Execute(ref player1, ref player2, TournamentModel.Surface);
            }

            // Getting a random value between zero and sum of player scores.
            var randomValue = randomGenerator.Next(0, player1.CurrentMatchScore + player2.CurrentMatchScore);
            var hasPlayer1Won = randomValue < player1.CurrentMatchScore;

            Console.WriteLine($"    Id {player1.Id} match score: {player1.CurrentMatchScore}\n    Id {player2.Id} match score: {player2.CurrentMatchScore}");
            Console.WriteLine($"        Random result: {randomValue}");

            var winnerPlayer = hasPlayer1Won ? player1 : player2;
            var loserPlayer = hasPlayer1Won ? player2 : player1;

            Console.WriteLine($"        Winner is: {winnerPlayer.Id}");

            // Resetting relative player data before starting next match.
            player1.PreparePlayerForNextMatch();
            player2.PreparePlayerForNextMatch();

            Console.WriteLine($"            Id {winnerPlayer.Id} Experience Berfore Win: {winnerPlayer.Experience}");

            // Giving players their rewards
            for (int i = 0; i < MatchRewards.Count; ++i)
            {
                MatchRewards[i].Execute(ref winnerPlayer, ref loserPlayer);
            }

            Console.WriteLine($"            Id {winnerPlayer.Id} Experience After Win: {winnerPlayer.Experience}\n");

            return new PlayerModel[2] { winnerPlayer, loserPlayer };
        }

        #endregion Base Methods
    }
}
