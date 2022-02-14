using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisSimulation.Core.Tournaments;
using TennisSimulation.Models;
using TennisSimulation.Rewards;
using TennisSimulation.Rules;

namespace TennisSimulationTests
{
    [TestClass]
    public class TennisSimulationUnitTests
    {
        #region Moc Data

        private PlayerModel _player1 = new PlayerModel()
        {
            Id = 1,
            Experience = 100,
            CurrentMatchScore = 0,
            Hand = "left",
            Skills = new Skills()
            {
                Hard = 10,
                Clay = 10,
                Grass = 10,
            }
        };

        private PlayerModel _player2 = new PlayerModel()
        {
            Id = 2,
            Experience = 0,
            CurrentMatchScore = 0,
            Hand = "right",
            Skills = new Skills()
            {
                Hard = 0,
                Clay = 0,
                Grass = 0,
            }
        };

        #endregion

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void EliminationTournamentConstructor_ThrowsNull()
        {
            new EliminationTournament(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void LeagueTournamentConstructor_ThrowsNull()
        {
            new LeagueTournament(null);
        }

        [TestMethod]
        public void EliminationTournamentConstructor_Passes()
        {
            var model = new TournamentModel()
            {
                Id = 1,
                Type = "elimination",
                Surface = "clay"
            };

            new EliminationTournament(model);
        }

        [TestMethod]
        public void LeagueTournamentConstructor_Passes()
        {
            var model = new TournamentModel()
            {
                Id = 1,
                Type = "league",
                Surface = "hard"
            };

            new LeagueTournament(model);
        }

        [TestMethod]
        public void GroundTypeRule_Test()
        {
            _player1.PostProcess();
            _player2.PostProcess();

            var groundTypeRule = new GroundTypeRule(10, 0);
            groundTypeRule.Execute(_player1, _player2, "hard");

            var expectedWinnerValue = 10;
            var expectedLoserValue = 0;
            var actualWinnerValue = _player1.CurrentMatchScore;
            var actualLoserValue = _player2.CurrentMatchScore;

            Assert.AreEqual(expectedWinnerValue, actualWinnerValue, "Winner not gained score correctly");
            Assert.AreEqual(expectedLoserValue, actualLoserValue, "Loser not gained score correctly");
        }

        [TestMethod]
        public void DominantHandRule_Test()
        {
            var dominantHandRule = new DominantHandRule(7, 0);
            dominantHandRule.Execute(_player1, _player2, "hard");

            var expectedWinnerValue = 7;
            var expectedLoserValue = 0;
            var actualWinnerValue = _player1.CurrentMatchScore;
            var actualLoserValue = _player2.CurrentMatchScore;

            Assert.AreEqual(expectedWinnerValue, actualWinnerValue, "Winner not gained score correctly");
            Assert.AreEqual(expectedLoserValue, actualLoserValue, "Loser not gained score correctly");
        }

        [TestMethod]
        public void ExperienceRule_Test()
        {
            var experienceRule = new ExperienceRule(20, 0);
            experienceRule.Execute(_player1, _player2, "hard");

            var expectedWinnerValue = 20;
            var expectedLoserValue = 0;
            var actualWinnerValue = _player1.CurrentMatchScore;
            var actualLoserValue = _player2.CurrentMatchScore;

            Assert.AreEqual(expectedWinnerValue, actualWinnerValue, "Winner not gained score correctly");
            Assert.AreEqual(expectedLoserValue, actualLoserValue, "Loser not gained score correctly");
        }

        [TestMethod]
        public void ParticipationRule_Test()
        {
            var participationRule = new ParticipationRule(3, 0);
            participationRule.Execute(_player1, _player2, "hard");

            var expectedWinnerValue = 3;
            var expectedLoserValue = 3;
            var actualWinnerValue = _player1.CurrentMatchScore;
            var actualLoserValue = _player2.CurrentMatchScore;

            Assert.AreEqual(expectedWinnerValue, actualWinnerValue, "Winner not gained score correctly");
            Assert.AreEqual(expectedLoserValue, actualLoserValue, "Loser not gained score correctly");
        }

        [TestMethod]
        public void ExperienceReward_Test()
        {
            var experienceReward = new ExperienceReward(25, 0);
            experienceReward.Apply(_player1,_player2);

            var expectedWinnerValue = 125;
            var expectedLoserValue = 0;
            var actualWinnerValue = _player1.Experience;
            var actualLoserValue = _player2.Experience;

            Assert.AreEqual(expectedWinnerValue, actualWinnerValue, "Winner not gained experience correctly");
            Assert.AreEqual(expectedLoserValue, actualLoserValue, "Loser not gained experience correctly");
        }
    }
}
