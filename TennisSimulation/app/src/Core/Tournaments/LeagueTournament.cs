using System;
using System.Collections.Generic;
using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Core.Tournaments
{
    public class LeagueTournament : Tournament
    {
        private List<PlayerTuple> _matchList;

        public LeagueTournament(TournamentModel tournamentModel) : base(tournamentModel)
        {
        }

        public override void StartTournament(List<PlayerModel> participants)
        {
            Console.WriteLine($"----------Starting new {TournamentModel.Type.ToUpperInvariant()} with {TournamentModel.Surface.ToUpperInvariant()} surface----------\n");

            var randomGenerator = new Random();

            // Matching players first before starting random matches.
            MatchPlayers(participants);

            while (_matchList.Count > 0)
            {
                // To get random match order, getting a tuple from random index and removing that match from list
                var randomMatch = Utils.TennisSimulationUtils.GetRandomAndRemove<PlayerTuple>(_matchList, randomGenerator);
                var player1 = randomMatch.Player1;
                var player2 = randomMatch.Player2;
                PlayMatch(ref player1, ref player2, randomGenerator);
            }
        }

        /// <summary>
        /// Creates a tuple consisting of two players and stores it in a list.
        /// </summary>
        /// <param name="participants"></param>
        private void MatchPlayers(List<PlayerModel> participants)
        {
            _matchList = new List<PlayerTuple>();

            // Creating match-ups
            for (int i = 0; i < participants.Count; ++i)
            {
                // In order to get unique match-ups, start inner loop one step ahead
                for (int j = i + 1; j < participants.Count; ++j)
                {
                    var player1 = participants[i];
                    var player2 = participants[j];
                    var playerTuple = new PlayerTuple()
                    {
                        Player1 = player1,
                        Player2 = player2
                    };
                    _matchList.Add(playerTuple);
                }
            }
        }
    }

    /// <summary>
    /// Helps to store matched players.
    /// </summary>
    public class PlayerTuple
    {
        public PlayerModel Player1 { get; set; }
        public PlayerModel Player2 { get; set; }
    }
}
