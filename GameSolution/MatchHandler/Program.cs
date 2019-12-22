using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace MatchHandler
{

    class Program
    {

        static void Main(string[] args)
        {

            int playerID1 = 1;
            int playerID2 = 2;

            BaseClass player1Class = new DemoEngineClass1();
            BaseClass player2Class = new DemoEngineClass1();

            GameState state = new GameState(10, 10);

            int turnIndex = 0;

            while ( turnIndex < 20 )
            {

                turnIndex++;

                int turnAttempts = 0;

                int playerID = 0;

                while ( turnAttempts < 10 )
                {

                    RequestedLine requestedNextMove = null;

                    turnAttempts++;

                    if (turnIndex % 2 == 0)
                    {

                        playerID = playerID1;
                        requestedNextMove = player1Class.MakeNextMove();

                    }
                    else
                    {

                        playerID = playerID2;
                        requestedNextMove = player2Class.MakeNextMove();

                    }

                    if ( ! ( Utilities.LineIsValid(requestedNextMove, state) ) )
                    {
                        continue;
                    }
                    else
                    {
                        Line nextMoveLine = new Line(requestedNextMove.Start, requestedNextMove.End, playerID);
                        state.addLine(nextMoveLine);
                        Utilities.LogError($"player with ID: {playerID} add line from {nextMoveLine.Start} to {nextMoveLine.End}");
                    }

                }

                player1Class.ProcessLastMove(state);
                player2Class.ProcessLastMove(state);

            }

            Console.WriteLine("done");
            Console.ReadLine();

        }

    }

}
