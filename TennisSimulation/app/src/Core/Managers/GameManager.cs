using System;
using System.Collections.Generic;
using System.Linq;
using TennisSimulation.Enums;
using TennisSimulation.Factory;
using TennisSimulation.Models;
using TennisSimulation.Utils;

namespace TennisSimulation.Core
{
    /// <summary>
    /// Responsible from starting tournaments and calculating results. Write outputs out into a json file.
    /// </summary>
    public class GameManager
    {
        #region Fields

        private InputData _inputData;
        private List<PlayerResultModel> _results = new List<PlayerResultModel>();

        #endregion

        #region Constructor

        public GameManager()
        {
            GetInputData();
            InitializePlayerResultModels();
        }

        #endregion

        /// <summary>
        /// Initializes and gets input data model which contains player and tournament lists.
        /// </summary>
        private void GetInputData()
        {
            _inputData = new InputData(Constants.JSON_FILENAME.INPUT_FILE_NAME);
        }

        /// <summary>
        /// Initializes results model for each player stores them in a list.
        /// </summary>
        private void InitializePlayerResultModels()
        {
            if (_inputData == null || !_inputData.PlayerModels.Any())
            {
                Console.WriteLine("Failed to read player models from input");
                return;
            }

            for (int i = 0; i < _inputData.PlayerModels.Count; ++i)
            {
                // Initializing player result model to create output data at the end of tournaments.
                _results.Add(new PlayerResultModel()
                {
                    Id = _inputData.PlayerModels[i].Id,
                    TotalExperience = _inputData.PlayerModels[i].Experience,
                    GainedExperience = 0,
                    Order = 0,
                });
            }
        }

        /// <summary>
        /// Starts each tournament from input data one by one for every participants.
        /// </summary>
        public void RunTournaments()
        {
            Console.WriteLine("Starting all given tournaments in input file");

            for (int i = 0; i < _inputData.TournamentModels.Count; ++i)
            {
                var tournamentType = (TournamentType)Enum.Parse(typeof(TournamentType), _inputData.TournamentModels[i].Type, true);
                var currentTournament = TournamentFactory.GetTournament(tournamentType, _inputData.TournamentModels[i]);
                if (currentTournament != null)
                {
                    currentTournament.StartTournament(_inputData.PlayerModels);
                }
            }
            Console.WriteLine("All tournaments are concluded. Waiting for results...");
            CalculateResults();
        }

        /// <summary>
        /// At the end of all tournaments sorts players by their total experiences and converts the sorted list to json file.
        /// </summary>
        private void CalculateResults()
        {
            // calculating gained experience, at start we initialized total experience as players intial experience.
            for (int i = 0; i < _results.Count; ++i)
            {
                _results[i].GainedExperience = _inputData.PlayerModels[i].Experience - _results[i].TotalExperience;
                _results[i].TotalExperience = _inputData.PlayerModels[i].Experience;
            }

            SortPlayersByExperience(_results);

            // Initializing order property in result model.
            for (int i = 0; i < _results.Count; ++i)
            {
                _results[i].Order = i+1;
            }

            TennisSimulationUtils.SerializeObjectToJsonFile<List<PlayerResultModel>>(Constants.JSON_FILENAME.OUPUT_FILE_NAME, _results);
            Console.WriteLine($"Output result file created under Resources file with file name: {Constants.JSON_FILENAME.OUPUT_FILE_NAME}");
        }

        /// <summary>
        /// Sorts players by theirs total experience. Also checks for initial experiences if total experiences of 2 players are the same.
        /// </summary>
        /// <param name="playerResults"></param>
        private void SortPlayersByExperience(List<PlayerResultModel> playerResults)
        {
            var temp = playerResults[0];

            // simple bubble sort algorithm. Sorting players in descending order.
            for (int i = 0; i < playerResults.Count; ++i)
            {
                for (int j = 0; j < playerResults.Count - 1; ++j)
                {
                    if (playerResults[j].TotalExperience < playerResults[j + 1].TotalExperience)
                    {
                        temp = playerResults[j + 1];
                        playerResults[j + 1] = _results[j];
                        playerResults[j] = temp;
                    }

                    // When 2 players' total experiences are the same, we are checking intial experience.
                    else if (playerResults[j].TotalExperience == playerResults[j + 1].TotalExperience)
                    {
                        var initialExperienceFirst = playerResults[j].TotalExperience - playerResults[j].GainedExperience;
                        var initialExperienceSecond = playerResults[j + 1].TotalExperience - playerResults[j + 1].GainedExperience;

                        if (initialExperienceFirst < initialExperienceSecond)
                        {
                            temp = playerResults[j + 1];
                            playerResults[j + 1] = _results[j];
                            playerResults[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
