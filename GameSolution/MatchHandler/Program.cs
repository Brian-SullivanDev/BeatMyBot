using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using static GameEngine.Utilities;
using Matchmaking;

namespace MatchHandlerConsole
{

    class Program
    {

        /// <summary>
        /// fire off the main event for this console application.  Stage the match between two players
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int playerID1 = 1;
            int playerID2 = 3;

            MatchHandler gameEngine = new MatchHandler(playerID1, playerID2, 10, 10);

            gameEngine.RunMatch();

            Console.Write(gameEngine.GameLog);

            Console.WriteLine("done");
            Console.ReadLine();

        }

    }

}
