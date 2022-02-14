using System;
using System.Collections.Generic;
using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Core.Tournaments
{
    /// <summary>
    /// Everyone matches each other once and matches are played in random order
    /// </summary>
    public class LeagueTournament : Tournament
    {
        private List<PlayerTuple> _matchList;

        public LeagueTournament(TournamentModel tournamentModel) : base(tournamentModel)
        {
        }

        public override void StartTournament(List<PlayerModel> participants)
        {
            var randomGenerator = new Random();

            // Creating all possible match-ups first.
            MatchPlayers(participants);

            while (_matchList.Count > 0)
            {
                // To get random match order, getting a tuple from random index and removing that tuple from list
                var randomMatch = Utils.TennisSimulationUtils.GetRandomAndRemove<PlayerTuple>(_matchList, randomGenerator);
                var player1 = randomMatch.Player1;
                var player2 = randomMatch.Player2;
                PlayMatch(player1, player2, randomGenerator);
            }
        }

        /// <summary>
        /// Creates a tuple consisting of two players and stores it in a list.
        /// This method will store all possible unique match-ups.
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
