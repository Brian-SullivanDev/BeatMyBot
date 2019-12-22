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

        public Line(Point start, Point end, int playerID) : base(start, end)
        {

            _playerID = playerID;

        }

    }

}
