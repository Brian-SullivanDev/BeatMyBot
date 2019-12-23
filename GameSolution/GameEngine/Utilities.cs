using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine
{

    public static class Utilities
    {

        public static void LogError (string errorDetails)
        {

            var context = new StackFrame(1);

            string errorFunction = context.GetMethod().Name;

            Logger.Instance.LogError(errorFunction, errorDetails);

        }

        /// <summary>
        /// Get a list of all possible adjacent points within the game grid
        /// </summary>
        /// <param name="origin">point to collect adjacent points for</param>
        /// <param name="height">height of game grid</param>
        /// <param name="width">width of game grid</param>
        public static List<Point> GetAdjacentPoints (Point origin, int height, int width)
        {

            List<Point> adjacentPoints = new List<Point>();

            try
            {

                if (origin.X > 0)
                {

                    adjacentPoints.Add(new Point(origin.X - 1, origin.Y));

                }

                if (origin.X < (width - 1))
                {

                    adjacentPoints.Add(new Point(origin.X + 1, origin.Y));

                }

                if (origin.Y > 0)
                {

                    adjacentPoints.Add(new Point(origin.X, origin.Y - 1));

                }

                if (origin.Y < (height - 1))
                {

                    adjacentPoints.Add(new Point(origin.X, origin.Y + 1));

                }

            }
            catch (Exception ex)
            {
                LogError($"(ex) - {ex.Message}");
            }

            return adjacentPoints;

        }

        /// <summary>
        /// Returns true if the line requested is possible according to the current game state and false otherwise
        /// </summary>
        /// <param name="line">new line</param>
        /// <param name="state">current game state</param>
        public static bool LineIsValid (RequestedLine line, GameState state)
        {

            bool lineIsValid = false;

            try
            {

                if (line == null)
                {
                    return false;
                }

                List<Point> adjacentPoints = GetAdjacentPoints(line.Start, state.Height, state.Width);

                for ( int index = 0; index < adjacentPoints.Count; ++index )
                {

                    Point testPoint = adjacentPoints[index];

                    if (testPoint == line.End)
                    {
                        return (!(LineAlreadyExists(line, state)));
                    }

                }

                return false;

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return lineIsValid;

        }

        /// <summary>
        /// returns true if the line already exists within the game state
        /// </summary>
        /// <param name="line">new line</param>
        /// <param name="state">current game state</param>
        public static bool LineAlreadyExists (RequestedLine line, GameState state)
        {

            bool lineAlreadyExists = false;

            try
            {

                for ( int index = 0; index < state.Lines.Count; ++index )
                {

                    Line existingLine = state.Lines[index];

                    if ( existingLine.Start == line.Start && existingLine.End == line.End )
                    {

                        return true;

                    }

                }
                
            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return lineAlreadyExists;

        }

    }

}
