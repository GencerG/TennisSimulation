using System;
using System.Collections.Generic;
using TennisSimulation.Interface;
using TennisSimulation.Models;
using TennisSimulation.Utils;

namespace TennisSimulation.Core.Tournaments
{
    public class EliminationTournament : Tournament
    {
        public EliminationTournament(TournamentModel tournamentModel) : base(tournamentModel)
        {
        }

        public override void StartTournament(List<PlayerModel> participants)
        {
            var upperBracket = new List<PlayerModel>();
            var randomGenerator = new Random();

            Console.WriteLine("Starting First Round");
            Console.WriteLine(participants.Count);

            // Matching players randomly just for the first round
            while (participants.Count > 0)
            {
                var player1 = participants[randomGenerator.Next(0, participants.Count)];
                participants.Remove(player1);

                var player2 = participants[randomGenerator.Next(0, participants.Count)];
                participants.Remove(player2);

                var winnerPlayer = PlayMatch(ref player1, ref player2, randomGenerator);
                upperBracket.Add(winnerPlayer);
            }

            // Matching players in order for the further rounds
            while (upperBracket.Count > 1)
            {
                Console.WriteLine($"Starting Round with {upperBracket.Count }");

                var matchAmount = upperBracket.Count / 2;
                for (int i = 0; i < matchAmount; ++i)
                {
                    var player1 = upperBracket[i];
                    var player2 = upperBracket[i+1];
                    var winnerPlayer = PlayMatch(ref player1, ref player2, randomGenerator);
                    upperBracket.Remove(winnerPlayer.Id == player1.Id ? player2 : player1);
                }
            }

            Console.WriteLine("Winner Id is: " + upperBracket[0].Id);
        }
    }
}
