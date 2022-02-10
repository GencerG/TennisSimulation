using System;
using System.Collections.Generic;
using TennisSimulation.Models;

namespace TennisSimulation.Abstracts
{
    public abstract class Tournament
    {
        public Tournament (TournamentModel tournamentModel)
        {
            TournamentModel = tournamentModel;
        }

        private Tournament() { }

        protected TournamentModel TournamentModel;
        protected List<Rule> Rules = new List<Rule>();
        protected List<Reward> MatchRewards = new List<Reward>();

        public abstract void StartTournament(List<PlayerModel> participants);

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

        protected virtual PlayerModel PlayMatch(ref PlayerModel player1, ref PlayerModel player2, Random randomGenerator)
        {
            Console.WriteLine($"Id {player1.Id} is playing against Id {player2.Id} in a {TournamentModel.Type.ToUpperInvariant()} match");

            for (int i = 0; i < Rules.Count; ++i)
            {
                Rules[i].Execute(ref player1, ref player2, TournamentModel.Surface);
            }

            var randomValue = randomGenerator.Next(0, player1.CurrentMatchScore + player2.CurrentMatchScore);
            var hasPlayer1Won = randomValue < player1.CurrentMatchScore;

            Console.WriteLine($"    Id {player1.Id} match score: {player1.CurrentMatchScore}\n    Id {player2.Id} match score: {player2.CurrentMatchScore}");
            Console.WriteLine($"        Random result: {randomValue}");

            var winnerPlayer = hasPlayer1Won ? player1 : player2;
            var loserPlayer = hasPlayer1Won ? player2 : player1;

            Console.WriteLine($"        Winner is: {winnerPlayer.Id}");

            player1.PreparePlayer();
            player2.PreparePlayer();

            Console.WriteLine($"            Id {winnerPlayer.Id} Experience Berfore Win: {winnerPlayer.Experience}");
            for (int i = 0; i < MatchRewards.Count; ++i)
            {
                MatchRewards[i].Execute(ref winnerPlayer, ref loserPlayer);
            }
            Console.WriteLine($"            Id {winnerPlayer.Id} Experience After Win: {winnerPlayer.Experience}\n");

            return winnerPlayer;
        }
    }
}
