using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using static GameEngine.Utilities;

namespace MatchHandler
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
            int playerID2 = 2;

            GameState state = new GameState(10, 10);

            BaseClass player1Class = new DemoEngineClass1(state);
            BaseClass player2Class = new DemoEngineClass1(state);

            int turnIndex = 0;

            int totalLines = (state.Height * (state.Width - 1)) + (state.Width * (state.Height - 1));

            int playerID = playerID1;

            bool playSwitchesHands = false;

            while ( turnIndex < totalLines)
            {

                if (playSwitchesHands == true)
                {
                    playerID = DetermineNextPlayerID(playerID, playerID1, playerID2);
                }

                playSwitchesHands = true;

                turnIndex++;

                int turnAttempts = 0;

                while ( turnAttempts < 10 )
                {

                    RequestedLine requestedNextMove = null;

                    turnAttempts++;

                    if (playerID == playerID1)
                    {

                        requestedNextMove = player1Class.MakeNextMove();

                    }
                    else
                    {

                        requestedNextMove = player2Class.MakeNextMove();

                    }

                    if ( ! ( LineIsValid(requestedNextMove, state) ) )
                    {
                        LogError($"player with ID: {playerID} failed to issue a valid move.  {10 - turnAttempts} attempts remaining.");
                        continue;
                    }
                    else
                    {
                        if ( LineWillCloseABox(state, requestedNextMove) == true )
                        {
                            playSwitchesHands = false;
                        }
                        Line nextMoveLine = new Line(requestedNextMove.Start, requestedNextMove.End, playerID);
                        state.addLine(nextMoveLine);
                        LogError($"player with ID: {playerID} added a line from {nextMoveLine.Start} to {nextMoveLine.End}");
                        break;
                    }

                }

                player1Class.ProcessLastMove(state);
                player2Class.ProcessLastMove(state);

            }

            Console.WriteLine("done");
            Console.ReadLine();

        }

        /// <summary>
        /// get the ID of the player to go next based on the current player's ID
        /// </summary>
        static int DetermineNextPlayerID (int currentID, int firstID, int secondID)
        {

            if ( currentID == firstID )
            {
                return secondID;
            }
            else
            {
                return firstID;
            }

        }

    }

}
