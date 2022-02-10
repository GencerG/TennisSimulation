using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TennisSimulation.Utils
{
    public static class TennisSimulationUtils
    {
        #region Constants

        public readonly struct Constants
        {
            public readonly struct JSON_PROPERTIES
            {
                public const string ID = "id";
                public const string EXPERIENCE = "experience";
                public const string HAND = "hand";
                public const string SKILLS = "skills";
                public const string GAINED_EXPERIENCE = "gained_experience";
                public const string TOTAL_EXPERIENCE = "total_experience";
                public const string ORDER = "order";
                public const string CLAY = "clay";
                public const string GRASS = "grass";
                public const string HARD = "hard";
            }
        }

        #endregion

        #region Helper Methods

        public static T GetJsonFromFile<T>(string fileName)
        {
            var enviroment = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            var path = Path.Combine(projectDirectory, "app", "src", "Resources", fileName);
            var jsonString = File.ReadAllText(path);
            var json = JsonConvert.DeserializeObject<T>(jsonString);
            return json;
        }

        public static void SerializeJsonToFile<T>(string fileName, T obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var enviroment = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            var path = Path.Combine(projectDirectory, "app", "src", "Resources", fileName);
            File.WriteAllText(path, jsonString);
        }

        public static T GetRandomAndRemove<T>(this List<T> list, Random randomGenerator)
        {
            var item = list[randomGenerator.Next(0, list.Count)];
            list.Remove(item);
            return item;
        }

        #endregion
    }
}
