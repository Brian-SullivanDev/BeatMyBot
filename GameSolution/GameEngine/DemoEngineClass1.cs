using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{

    public class DemoEngineClass1 : BaseClass
    {

        public DemoEngineClass1 (GameState initialState) : base (initialState)
        {

        }

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

        private RequestedLine FindFirstAvailableLine ()
        {

            RequestedLine requestedLine = null;

            for (int row = 0; row < State.Height; ++row)
            {

                for (int col = 0; col < State.Width; ++col)
                {

                    Point possiblePoint = new Point(col, row);

                    List<Point> adjacentPoints = Utilities.GetAdjacentPoints(possiblePoint, State.Height, State.Width);

                    for (int index = 0; index < adjacentPoints.Count; ++index)
                    {

                        Point possibleEndPoint = adjacentPoints[index];

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
