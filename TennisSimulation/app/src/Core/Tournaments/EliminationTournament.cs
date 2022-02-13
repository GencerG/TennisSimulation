using System;
using System.Collections.Generic;
using TennisSimulation.Abstracts;
using TennisSimulation.Models;

namespace TennisSimulation.Core.Tournaments
{
    public class EliminationTournament : Tournament
    {
        public EliminationTournament(TournamentModel tournamentModel) : base(tournamentModel)
        {
        }

        public override void StartTournament(List<PlayerModel> participants)
        {
            Console.WriteLine($"----------Starting new {TournamentModel.Type.ToUpperInvariant()} with {TournamentModel.Surface.ToUpperInvariant()} surface----------\n");

            var upperBracket = new List<PlayerModel>();
            var randomGenerator = new Random();
            var availablePlayersForNextTournament = new List<PlayerModel>();

            // Matching players randomly just for the first round. Removing matching players from list in order to get new random match-up.
            while (participants.Count > 0)
            {
                var player1 = Utils.TennisSimulationUtils.GetRandomAndRemove<PlayerModel>(participants, randomGenerator);
                var player2 = Utils.TennisSimulationUtils.GetRandomAndRemove<PlayerModel>(participants, randomGenerator);

                var players = PlayMatch(player1, player2, randomGenerator);
                upperBracket.Add(players[0]);
                availablePlayersForNextTournament.Add(players[1]);
            }

            // In upper bracket, match-ups will be in order since they are already determined.
            // Removing losing player from upper bracket list until we will have only one player.
            while (upperBracket.Count > 1)
            {
                Console.WriteLine($"Starting Round with {upperBracket.Count }");

                var matchAmount = upperBracket.Count / 2;
                for (int i = 0; i < matchAmount; ++i)
                {
                    var player1 = upperBracket[i];
                    var player2 = upperBracket[i+1];
                    var players = PlayMatch(player1, player2, randomGenerator);
                    upperBracket.Remove(players[1]);
                    availablePlayersForNextTournament.Add(players[1]);
                }
            }

            // Since all class instances pass by reference, we actually removing players from our PlayerModel list from input data.
            // So we have to fill the PlayerModel list again.
            availablePlayersForNextTournament.Add(upperBracket[0]);
            for (int i = 0; i < availablePlayersForNextTournament.Count; ++i)
            {
                participants.Add(availablePlayersForNextTournament[i]);
            }
            Console.WriteLine("Winner Id is: " + upperBracket[0].Id);
        }
    }
}
