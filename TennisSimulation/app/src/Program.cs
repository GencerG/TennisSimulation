using System;
using TennisSimulation.Core;

namespace TennisSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GameManager();
            gm.RunTournaments();
            Console.ReadLine();
        }
    }
}
