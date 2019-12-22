using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{

    public class GameState
    {

        private int _height;

        public int Height
        {
            get
            {
                return _height;
            }
        }

        private int _width;

        public int Width
        {
            get
            {
                return _width;
            }
        }

        private List<Line> _lines;

        public List<Line> Lines
        {
            get
            {
                return _lines;
            }
        }

    }

}
