using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine
{

    public static class Utilities
    {

        /// <summary>
        /// invokes the Logger object in order to log an error according to the details provided and the context the request comes from
        /// </summary>
        /// <param name="errorDetails">details to log with the context of the calling sequence</param>
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

                    if ( existingLine.Start == line.Start && existingLine.End == line.End ||
                       existingLine.Start == line.End && existingLine.End == line.Start)
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

        /// <summary>
        /// returns false if any line in the collection do not already exist.  Returns true otherwise
        /// </summary>
        public static bool LinesAlreadyExist(List<RequestedLine> lines, GameState state)
        {

            bool linesAlreadyExist = false;

            try
            {

                foreach (RequestedLine line in lines)
                {

                    if (!(LineAlreadyExists(line, state)))
                    {
                        return linesAlreadyExist;
                    }

                }

                linesAlreadyExist = true;

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return linesAlreadyExist;

        }

        /// <summary>
        /// returns true if the requested line would close a box
        /// </summary>
        /// <param name="state">current game state</param>
        /// <param name="line">requested line</param>
        public static bool LineWillCloseABox (GameState state, RequestedLine line)
        {

            bool lineClosesBox = false;

            try
            {

                Point start = line.Start;
                Point end = line.End;

                if ( start.X != end.X )
                {
                    return LineClosesHorizontalBox(state, line);
                }
                else
                {
                    return LineClosesVerticalBox(state, line);
                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return lineClosesBox;

        }

        /// <summary>
        /// returns true if the requested horizontal line would close a box
        /// </summary>
        /// <param name="state">current game state</param>
        /// <param name="line">requested line</param>
        public static bool LineClosesHorizontalBox(GameState state, RequestedLine line)
        {

            bool lineClosesBox = false;

            try
            {

                Point start = line.Start;
                Point end = line.End;

                if ( start.Y < state.Height - 1 )
                {
                    var leftLineBelow = new RequestedLine(new Point(start.X, start.Y), new Point(start.X, start.Y + 1));
                    var rightLineBelow = new RequestedLine(new Point(end.X, end.Y), new Point(end.X, end.Y + 1));
                    var bottomLineBelow = new RequestedLine(new Point(start.X, start.Y + 1), new Point(end.X, end.Y + 1));

                    var checkLines = new List<RequestedLine>()
                    {
                        leftLineBelow,
                        rightLineBelow,
                        bottomLineBelow
                    };

                    if (LinesAlreadyExist(checkLines, state))
                    {
                        lineClosesBox = true;
                    }
                }

                if ( start.Y > 0 )
                {

                    var leftLineAbove = new RequestedLine(new Point(start.X, start.Y), new Point(start.X, start.Y - 1));
                    var rightLineAbove = new RequestedLine(new Point(end.X, end.Y), new Point(end.X, end.Y - 1));
                    var topLineAbove = new RequestedLine(new Point(start.X, start.Y - 1), new Point(end.X, end.Y - 1));

                    var checkLines = new List<RequestedLine>()
                    {
                        leftLineAbove,
                        rightLineAbove,
                        topLineAbove
                    };

                    if ( LinesAlreadyExist(checkLines, state) )
                    {
                        lineClosesBox = true;
                    }
                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return lineClosesBox;

        }

        /// <summary>
        /// returns true if the requested vertical line would close a box
        /// </summary>
        /// <param name="state">current game state</param>
        /// <param name="line">requested line</param>
        public static bool LineClosesVerticalBox(GameState state, RequestedLine line)
        {

            bool lineClosesBox = false;

            try
            {

                Point start = line.Start;
                Point end = line.End;

                if (start.X < state.Width - 1)
                {
                    var topLineRight = new RequestedLine(new Point(start.X, start.Y), new Point(start.X + 1, start.Y));
                    var bottomLineRight = new RequestedLine(new Point(end.X, end.Y), new Point(end.X + 1, end.Y));
                    var rightLineRight = new RequestedLine(new Point(start.X + 1, start.Y), new Point(end.X + 1, end.Y));

                    var checkLines = new List<RequestedLine>()
                    {
                        topLineRight,
                        bottomLineRight,
                        rightLineRight
                    };

                    if (LinesAlreadyExist(checkLines, state))
                    {
                        lineClosesBox = true;
                    }
                }

                if (start.X > 0)
                {

                    var topLineLeft = new RequestedLine(new Point(start.X, start.Y), new Point(start.X - 1, start.Y));
                    var bottomLineLeft = new RequestedLine(new Point(end.X, end.Y), new Point(end.X - 1, end.Y));
                    var leftLineLeft = new RequestedLine(new Point(start.X - 1, start.Y), new Point(end.X - 1, end.Y));

                    var checkLines = new List<RequestedLine>()
                    {
                        topLineLeft,
                        bottomLineLeft,
                        leftLineLeft
                    };

                    if (LinesAlreadyExist(checkLines, state))
                    {
                        lineClosesBox = true;
                    }
                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return lineClosesBox;

        }

        /// <summary>
        /// return the value casted as an integer or a default value of 0 if the value could not be cast
        /// </summary>
        /// <param name="value">value to cast to an integer</param>
        public static int CheckNullInt(object value)
        {
            try
            {

                return Int32.Parse(value.ToString());

            }
            catch (Exception)
            {
                return 0;
            }
        }

    }

}
