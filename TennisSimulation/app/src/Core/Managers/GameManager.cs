using System;
using System.Collections.Generic;
using System.Linq;
using TennisSimulation.Enums;
using TennisSimulation.Factory;
using TennisSimulation.Models;

namespace TennisSimulation.Core
{
    public class GameManager
    {
        #region Fields

        private InputData _inputDataHolder;
        private List<PlayerResultModel> _results = new List<PlayerResultModel>();

        #endregion

        #region Constructor

        public GameManager()
        {
            _inputDataHolder = new InputData("input.json");

            for (int i = 0; i < _inputDataHolder.PlayerModels.Count; ++i)
            {
                _results.Add(new PlayerResultModel()
                {
                    Id = _inputDataHolder.PlayerModels[i].Id,
                    TotalExperience = _inputDataHolder.PlayerModels[i].Experience,
                    GainedExperience = 0,
                    Order = 0,
                });
            }
        }

        #endregion

        public void RunTournaments()
        {
            for (int i = 0; i < 1; ++i)
            {
                var tournamentType = (TournamentType)Enum.Parse(typeof(TournamentType), _inputDataHolder.TournamentModels[i].Type, true);
                Console.WriteLine(tournamentType);
                var currentTournament = TournamentFactory.GetTournament(tournamentType, _inputDataHolder.TournamentModels[i]);
                if (currentTournament != null)
                {
                    Console.WriteLine("count is: " + _inputDataHolder.PlayerModels.Count);
                    currentTournament.StartTournament(_inputDataHolder.PlayerModels);
                }
            }

            EndGame();
        }

        private void EndGame()
        {
            for (int i = 0; i < _results.Count; ++i)
            {
                _results[i].GainedExperience = _inputDataHolder.PlayerModels[i].Experience - _results[i].TotalExperience;
                _results[i].TotalExperience = _inputDataHolder.PlayerModels[i].Experience;
            }

            _results = _results.OrderByDescending(totalExp => totalExp.TotalExperience).ToList();

            for (int i = 0; i < _results.Count; ++i)
            {
                _results[i].Order = i+1;
            }

            Utils.TennisSimulationUtils.SerializeJsonToFile<List<PlayerResultModel>>("result.json", _results);
        }
    }
}
