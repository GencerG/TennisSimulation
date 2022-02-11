using TennisSimulation.Abstracts;
using TennisSimulation.Core.Tournaments;
using TennisSimulation.Enums;
using TennisSimulation.Models;
using TennisSimulation.Rewards;
using TennisSimulation.Rules;

namespace TennisSimulation.Factory
{
    /// <summary>
    /// Creates a tournament by given <see cref="TournamentType"/>
    /// </summary>
    public static class TournamentFactory
    {
        public static Tournament GetTournament(TournamentType type, TournamentModel model)
        {
            switch (type)
            {
                case TournamentType.Elimination:
                    return new EliminationTournament(model)
                        .ApplyRule(new ExperienceRule(3, 0))
                        .ApplyRule(new DominantHandRule(2, 0))
                        .ApplyRule(new GroundTypeRule(4, 0))
                        .ApplyRule(new ParticipationRule(1, 0))
                        .ApplyMatchReward(new ExperienceReward(20, 10));

                case TournamentType.League:
                    return new LeagueTournament(model)
                        .ApplyRule(new ExperienceRule(3, 0))
                        .ApplyRule(new DominantHandRule(2, 0))
                        .ApplyRule(new GroundTypeRule(4, 0))
                        .ApplyRule(new ParticipationRule(1, 0))
                        .ApplyMatchReward(new ExperienceReward(10, 1));

                default:
                    return null;
            }
        }
    }
}