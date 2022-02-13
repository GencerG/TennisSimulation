using TennisSimulation.Abstracts;
using TennisSimulation.Core.Tournaments;
using TennisSimulation.Enums;
using TennisSimulation.Models;
using TennisSimulation.Rewards;
using TennisSimulation.Rules;
using TennisSimulation.Utils;

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
                        .ApplyRule(new ExperienceRule(Constants.RULES.EXPERIENCE.POINT_TO_WIN, Constants.RULES.EXPERIENCE.POINT_TO_LOSE))
                        .ApplyRule(new DominantHandRule(Constants.RULES.DOMINANT_HAND.POINT_TO_WIN, Constants.RULES.DOMINANT_HAND.POINT_TO_LOSE))
                        .ApplyRule(new GroundTypeRule(Constants.RULES.GROUND_TYPE.POINT_TO_WIN, Constants.RULES.GROUND_TYPE.POINT_TO_LOSE))
                        .ApplyRule(new ParticipationRule(Constants.RULES.PARTICIPATION.POINT_TO_WIN, Constants.RULES.PARTICIPATION.POINT_TO_LOSE))
                        .ApplyMatchReward(new ExperienceReward(20, 10));

                case TournamentType.League:
                    return new LeagueTournament(model)
                        .ApplyRule(new ExperienceRule(Constants.RULES.EXPERIENCE.POINT_TO_WIN, Constants.RULES.EXPERIENCE.POINT_TO_LOSE))
                        .ApplyRule(new DominantHandRule(Constants.RULES.DOMINANT_HAND.POINT_TO_WIN, Constants.RULES.DOMINANT_HAND.POINT_TO_LOSE))
                        .ApplyRule(new GroundTypeRule(Constants.RULES.GROUND_TYPE.POINT_TO_WIN, Constants.RULES.GROUND_TYPE.POINT_TO_LOSE))
                        .ApplyRule(new ParticipationRule(Constants.RULES.PARTICIPATION.POINT_TO_WIN, Constants.RULES.PARTICIPATION.POINT_TO_LOSE))
                        .ApplyMatchReward(new ExperienceReward(10, 1));

                default:
                    return null;
            }
        }
    }
}
