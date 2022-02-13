using System;
using System.Collections.Generic;
using System.Linq;
using TennisSimulation.Enums;
using TennisSimulation.Factory;
using TennisSimulation.Models;
using TennisSimulation.Utils;

namespace TennisSimulation.Core
{
    public class GameManager
    {
        #region Fields

        private InputData _inputData;
        private List<PlayerResultModel> _results = new List<PlayerResultModel>();

        #endregion

        #region Constructor

        public GameManager()
        {
            _inputData = new InputData(Constants.JSON_FILENAME.INPUT_FILE_NAME);

            for (int i = 0; i < _inputData.PlayerModels.Count; ++i)
            {
                _results.Add(new PlayerResultModel()
                {
                    Id = _inputData.PlayerModels[i].Id,
                    TotalExperience = _inputData.PlayerModels[i].Experience,
                    GainedExperience = 0,
                    Order = 0,
                });
            }
        }

        #endregion

        /// <summary>
        /// Starts each tournament from input data one by one for every participants.
        /// </summary>
        public void RunTournaments()
        {     
            for (int i = 0; i < _inputData.TournamentModels.Count; ++i)
            {
                var tournamentType = (TournamentType)Enum.Parse(typeof(TournamentType), _inputData.TournamentModels[i].Type, true);
                var currentTournament = TournamentFactory.GetTournament(tournamentType, _inputData.TournamentModels[i]);
                if (currentTournament != null)
                {
                    currentTournament.StartTournament(_inputData.PlayerModels);
                }
            }

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

            var temp = _results[0];

            // simple bubble sort algorithm. Sorting players in descending order.
            for (int i = 0; i < _results.Count; ++i)
            {
                for (int j = 0; j < _results.Count - 1; ++j)
                {
                    if (_results[j].TotalExperience < _results[j + 1].TotalExperience)
                    {
                        temp = _results[j + 1];
                        _results[j + 1] = _results[j];
                        _results[j] = temp;
                    }

                    // When 2 players' total expereinces are the same, we are checking intial experience.
                    else if (_results[j].TotalExperience == _results[j + 1].TotalExperience)
                    {
                        var initialExperienceFirst = _results[j].TotalExperience - _results[j].GainedExperience;
                        var initialExperienceSecond = _results[j+1].TotalExperience - _results[j+1].GainedExperience;

                        if (initialExperienceFirst < initialExperienceSecond)
                        {
                            temp = _results[j + 1];
                            _results[j + 1] = _results[j];
                            _results[j] = temp;
                        }
                    }
                }
            }

            // Initializing order property in result model.
            for (int i = 0; i < _results.Count; ++i)
            {
                _results[i].Order = i+1;
            }

            TennisSimulationUtils.SerializeObjectToJsonFile<List<PlayerResultModel>>(Constants.JSON_FILENAME.OUPUT_FILE_NAME, _results);
        }
    }
}
