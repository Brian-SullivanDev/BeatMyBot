using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{

    public class Line
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

        private int _playerID;

        public int PlayerID
        {
            get
            {
                return _playerID;
            }
        }

        public Line (Point start, Point end, int playerID)
        {
            _start = start;
            _end = end;
            _playerID = playerID;
        }

    }

}
