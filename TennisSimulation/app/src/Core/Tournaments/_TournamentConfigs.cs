namespace TennisSimulation.Tournaments
{
    public static class _TournamentConfigs
    {
        public readonly struct ELIMINATION
        {
            public readonly struct REWARDS
            {
                public readonly struct EXPERIENCE
                {
                    public const int WINNER_PRIZE = 20;
                    public const int LOSER_PRIZE = 10;
                }
            }
        }

        public readonly struct LEAGUE
        {
            public readonly struct REWARDS
            {
                public readonly struct EXPERIENCE
                {
                    public const int WINNER_PRIZE = 10;
                    public const int LOSER_PRIZE = 1;
                }
            }
        }
    }
}
