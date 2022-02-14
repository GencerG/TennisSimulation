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
}
