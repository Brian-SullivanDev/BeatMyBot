using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{

    public class RequestedLine
    {

        private Point _start;

        public Point Start
        {
            get
            {
                return _start;
            }
        }

        private Point _end;

        public Point End
        {
            get
            {
                return _end;
            }
        }

        /// <summary>
        /// The Requested Line object is a Line that has not yet been validated by the Game Engine as a Line that can be drawn 
        /// and has not already been drawn
        /// </summary>
        public RequestedLine (Point start, Point end)
        {
            _start = start;
            _end = end;
        }

    }

    public class Line : RequestedLine
    {

        private int _playerID;

        public int PlayerID
        {
            get
            {
                return _playerID;
            }
        }

        /// <summary>
        /// The Line object is a Request Line object that has been validated as a valid Line that has not yet been drawn. 
        /// The Line object reports the player ID of the player that requested the Line be drawn.
        /// </summary>
        public Line(Point start, Point end, int playerID) : base(start, end)
        {

            _playerID = playerID;

        }

    }

}
