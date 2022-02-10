using System.Collections.Generic;
using TennisSimulation.Models;

namespace TennisSimulation.Interface
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

        public abstract void StartTournament(List<PlayerModel> participants);

        public Tournament ApplyRule(Rule rule)
        {
            Rules.Add(rule);
            return this;
        }
    }
}
