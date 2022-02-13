using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TennisSimulation.Utils
{
    public static class TennisSimulationUtils
    {
        #region Helper Methods

        /// <summary>
        /// Helps to read from json file and converts it to relative class from given file name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T GetObjectFromJsonFile<T>(string fileName)
        {
            var enviroment = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            var path = Path.Combine(projectDirectory, "app", "src", "Resources", fileName);

            if (File.Exists(path))
            {
                var jsonString = File.ReadAllText(path);
                var deserializedObject = JsonConvert.DeserializeObject<T>(jsonString);
                return deserializedObject;
            }

            return default;
        }

        /// <summary>
        /// Helps to convert object to json file. Creates a file with given name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="obj"></param>
        public static void SerializeObjectToJsonFile<T>(string fileName, T obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var enviroment = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            var path = Path.Combine(projectDirectory, "app", "src", "Resources", fileName);
            File.WriteAllText(path, jsonString);
        }

        /// <summary>
        /// Returns item from random index in given List and removes that item from list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="randomGenerator"></param>
        /// <returns></returns>
        public static T GetRandomAndRemove<T>(this List<T> list, Random randomGenerator)
        {
            var item = list[randomGenerator.Next(0, list.Count)];
            list.Remove(item);
            return item;
        }

        #endregion
    }

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

        public readonly struct RULES
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
}
