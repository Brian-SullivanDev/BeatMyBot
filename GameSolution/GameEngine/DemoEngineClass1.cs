using System;
using System.Collections.Generic;
using System.Text;
using static GameEngine.Utilities;

namespace GameEngine
{

    public class DemoEngineClass1 : BaseClass
    {

        /// <summary>
        /// This player class will always request the next available ordinal Line
        /// </summary>
        public DemoEngineClass1 (GameState initialState, int playerID) : base (initialState, playerID)
        {

        }

        /// <summary>
        /// overrides the abstract provided in the base class.  This is the entry point from the calling program that allows us to customize our class and make it our own
        /// </summary>
        /// <returns>Next desired move in the game</returns>
        public override RequestedLine MakeNextMove()
        {

            RequestedLine requestedLine = null;

            try
            {

                requestedLine = FindFirstAvailableLine(State);

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return requestedLine;

        }

    }

}
