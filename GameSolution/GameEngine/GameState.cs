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

        public GameState (int height, int width)
        {

            _height = height;
            _width = width;
            _lines = new List<Line>();

        }

        public void addLine (Line line)
        {
            _lines.Add(line);
        }

    }

}
