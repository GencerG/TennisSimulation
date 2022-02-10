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

            // Matching players randomly just for the first round
            Console.WriteLine("Starting First Round");
            while (participants.Count > 0)
            {
                var player1 = participants.GetRandomAndRemove<PlayerModel>(randomGenerator);
                var player2 = participants.GetRandomAndRemove<PlayerModel>(randomGenerator);
                Console.WriteLine($"{player1.Id} is playing against {player2.Id}");
                var winnerPlayer = PlayMatch(ref player1, ref player2, randomGenerator);
                upperBracket.Add(winnerPlayer);
                Console.WriteLine($"Winner is: {winnerPlayer.Id}");
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
                    Console.WriteLine($"{player1.Id} is playing against {player2.Id}");
                    var winnerPlayer = PlayMatch(ref player1, ref player2, randomGenerator);
                    upperBracket.Remove(winnerPlayer.Id == player1.Id ? player2 : player1);
                    Console.WriteLine($"Winner is: {winnerPlayer.Id}");
                }
            }

            Console.WriteLine("Winner Id is: " + upperBracket[0].Id);
        }

        private PlayerModel PlayMatch(ref PlayerModel player1, ref PlayerModel player2, Random randomGenerator)
        {
            for (int i = 0; i < Rules.Count; ++i)
            {
                Rules[i].Execute(ref player1, ref player2, TournamentModel.Surface);
            }
            var randomValue = randomGenerator.Next(0, player1.CurrentMatchScore + player2.CurrentMatchScore);
            var hasPlayer1Won = randomValue < player1.CurrentMatchScore;
            Console.WriteLine($"    player 1 match score: {player1.CurrentMatchScore} \n   player 2 match score: {player2.CurrentMatchScore} \n");
            Console.WriteLine($"        Random result: {randomValue}");
            player1.PreparePlayer();
            player2.PreparePlayer();

            return (hasPlayer1Won ? player1 : player2);
        }
    }
}
