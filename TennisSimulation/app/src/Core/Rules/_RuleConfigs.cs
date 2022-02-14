namespace TennisSimulation.Rules
{
    public static class _RuleConfigs
    {
        public readonly struct DOMINANT_HAND
        {
            public const int POINT_TO_WIN = 2;
            public const int POINT_TO_LOSE = 0;
        }

        public readonly struct EXPERIENCE
        {
            public const int POINT_TO_WIN = 3;
            public const int POINT_TO_LOSE = 0;
        }

        public readonly struct GROUND_TYPE
        {
            public const int POINT_TO_WIN = 4;
            public const int POINT_TO_LOSE = 0;
        }

        public readonly struct PARTICIPATION
        {
            public const int POINT_TO_WIN = 1;
            public const int POINT_TO_LOSE = 0;
        }
    }
}
