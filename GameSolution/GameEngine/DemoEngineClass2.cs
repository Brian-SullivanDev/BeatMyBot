using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{

    public class DemoEngineClass2 : BaseClass
    {

        /// <summary>
        /// This player class will always request a random Line that is still available
        /// </summary>
        public DemoEngineClass2 (GameState initialState, int playerID) : base(initialState, playerID)
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

                requestedLine = FindFirstAvailableLine();

            }
            catch (Exception ex)
            {
                Utilities.LogError("(ex) - " + ex.Message);
            }

            return requestedLine;

        }

        /// <summary>
        /// Find the first available line that can be drawn and request it (null if none can be found)
        /// </summary>
        private RequestedLine FindFirstAvailableLine()
        {

            RequestedLine requestedLine = null;

            List<int> rowsRandomlyChosen = new List<int>();

            Random random = new Random();

            while (rowsRandomlyChosen.Count < State.Height)
            {

                int nextRowAttempt = random.Next(State.Height);

                while (rowsRandomlyChosen.IndexOf(nextRowAttempt) >= 0)
                {
                    nextRowAttempt = random.Next(State.Height);
                }

                rowsRandomlyChosen.Add(nextRowAttempt);

                List<int> colsRandomlyChosen = new List<int>();

                while (colsRandomlyChosen.Count < State.Width)
                {

                    int nextColAttempt = random.Next(State.Width);

                    while (colsRandomlyChosen.IndexOf(nextColAttempt) >= 0)
                    {
                        nextColAttempt = random.Next(State.Height);
                    }

                    colsRandomlyChosen.Add(nextColAttempt);

                    Point possiblePoint = new Point(nextColAttempt, nextRowAttempt);

                    List<Point> adjacentPoints = Utilities.GetAdjacentPoints(possiblePoint, State.Height, State.Width);

                    List<int> adjacentPointsTried = new List<int>();

                    while (adjacentPointsTried.Count < adjacentPoints.Count)
                    {

                        int nextAdjacentPoint = random.Next(adjacentPoints.Count);

                        while (adjacentPointsTried.IndexOf(nextAdjacentPoint) >= 0)
                        {

                            nextAdjacentPoint = random.Next(adjacentPoints.Count);

                        }

                        adjacentPointsTried.Add(nextAdjacentPoint);

                        Point possibleEndPoint = adjacentPoints[nextAdjacentPoint];

                        RequestedLine possibleLine = new RequestedLine(possiblePoint, possibleEndPoint);

                        if (Utilities.LineIsValid(possibleLine, State))
                        {
                            return possibleLine;
                        }

                    }

                }

            }

            return requestedLine;

        }

    }

}
