using System;
using System.Collections.Generic;
using System.Linq;
using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Core.Tournaments
{
    public class LeagueTournament : Tournament
    {
        public LeagueTournament(TournamentModel tournamentModel) : base(tournamentModel)
        {
        }

        public override void StartTournament(List<PlayerModel> participants)
        {
            Console.WriteLine($"----------Starting new {TournamentModel.Type.ToUpperInvariant()} with {TournamentModel.Surface.ToUpperInvariant()} surface----------\n");
            var randomGenerator = new Random();
            var playersWaitingForNextRound = new List<PlayerModel>();

            for (int i = 0; i < participants.Count - 1; ++i)
            {
                playersWaitingForNextRound.Clear();

                for (int j = 0; j < participants.Count / 2; ++j)
                {
                    var availablePlayers = participants.ToList();

                    for (int k = 0; k < playersWaitingForNextRound.Count; ++k)
                    {
                        availablePlayers.Remove(playersWaitingForNextRound[k]);
                    }

                    var player1 = availablePlayers[randomGenerator.Next(0, availablePlayers.Count)];
                    availablePlayers.Remove(player1);

                    for (int k = 0; k < player1.PlayedAgainstIds.Count; ++k)
                    {
                        var playedAgainstPlayer = participants.Find(player => player.Id == player1.PlayedAgainstIds[k]);
                        availablePlayers.Remove(playedAgainstPlayer);
                    }

                    var player2 = availablePlayers[randomGenerator.Next(0, availablePlayers.Count)];

                    player1.PlayedAgainstIds.Add(player2.Id);
                    player2.PlayedAgainstIds.Add(player1.Id);

                    playersWaitingForNextRound.Add(player1);
                    playersWaitingForNextRound.Add(player2);

                    PlayMatch(ref player1, ref player2, randomGenerator);
                }
            }
        }
    }
}
