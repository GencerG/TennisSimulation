namespace TennisSimulation.Utils
{
    public static class Constants
    {
        public readonly struct JSON_PROPERTIES
        {
            public const string ID = "id";
            public const string EXPERIENCE = "experience";
            public const string PLAYERS = "players";
            public const string TOURNAMENTS = "tournaments";
            public const string HAND = "hand";
            public const string SKILLS = "skills";
            public const string GAINED_EXPERIENCE = "gained_experience";
            public const string TOTAL_EXPERIENCE = "total_experience";
            public const string ORDER = "order";
            public const string CLAY = "clay";
            public const string GRASS = "grass";
            public const string HARD = "hard";
            public const string SURFACE = "surface";
            public const string TYPE = "type";
        }

        public readonly struct JSON_FILENAME
        {
            public const string INPUT_FILE_NAME = "input.json";
            public const string OUPUT_FILE_NAME = "output.json";
        }
    }
}
