using TennisSimulation.Abstracts;
using TennisSimulation.Core.Tournaments;
using TennisSimulation.Enums;
using TennisSimulation.Models;
using TennisSimulation.Rewards;
using TennisSimulation.Rules;
using TennisSimulation.Tournaments;

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
                        .SetRule(new ExperienceRule(_RuleConfigs.EXPERIENCE.POINT_TO_WIN, _RuleConfigs.EXPERIENCE.POINT_TO_LOSE))
                        .SetRule(new DominantHandRule(_RuleConfigs.DOMINANT_HAND.POINT_TO_WIN, _RuleConfigs.DOMINANT_HAND.POINT_TO_LOSE))
                        .SetRule(new GroundTypeRule(_RuleConfigs.GROUND_TYPE.POINT_TO_WIN, _RuleConfigs.GROUND_TYPE.POINT_TO_LOSE))
                        .SetRule(new ParticipationRule(_RuleConfigs.PARTICIPATION.POINT_TO_WIN, _RuleConfigs.PARTICIPATION.POINT_TO_LOSE))
                        .SetMatchReward(new ExperienceReward(_TournamentConfigs.ELIMINATION.REWARDS.EXPERIENCE.WINNER_PRIZE,
                         _TournamentConfigs.ELIMINATION.REWARDS.EXPERIENCE.LOSER_PRIZE));

                case TournamentType.League:
                    return new LeagueTournament(model)
                        .SetRule(new ExperienceRule(_RuleConfigs.EXPERIENCE.POINT_TO_WIN, _RuleConfigs.EXPERIENCE.POINT_TO_LOSE))
                        .SetRule(new DominantHandRule(_RuleConfigs.DOMINANT_HAND.POINT_TO_WIN, _RuleConfigs.DOMINANT_HAND.POINT_TO_LOSE))
                        .SetRule(new GroundTypeRule(_RuleConfigs.GROUND_TYPE.POINT_TO_WIN, _RuleConfigs.GROUND_TYPE.POINT_TO_LOSE))
                        .SetRule(new ParticipationRule(_RuleConfigs.PARTICIPATION.POINT_TO_WIN, _RuleConfigs.PARTICIPATION.POINT_TO_LOSE))
                        .SetMatchReward(new ExperienceReward(_TournamentConfigs.LEAGUE.REWARDS.EXPERIENCE.WINNER_PRIZE,
                        _TournamentConfigs.LEAGUE.REWARDS.EXPERIENCE.WINNER_PRIZE));

                default:
                    return null;
            }
        }
    }
}
