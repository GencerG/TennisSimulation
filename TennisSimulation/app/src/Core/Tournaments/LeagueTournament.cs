using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisSimulation.Interface;
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
            var randomGenerator = new Random();

            for (int i = 0; i < participants.Count; ++i)
            {
                for (int j = i + 1; j < participants.Count; ++j)
                {
                    var player1 = participants[i];
                    var player2 = participants[j];
                    PlayMatch(ref player1, ref player2, randomGenerator);
                }
            }
        }
    }
}
