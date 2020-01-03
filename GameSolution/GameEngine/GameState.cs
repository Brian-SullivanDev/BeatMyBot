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

        /// <summary>
        /// The Game State object tracks the dimensions of the game as well as the Lines that have been drawn within the game
        /// </summary>
        public GameState (int height, int width)
        {

            _height = height;
            _width = width;
            _lines = new List<Line>();

        }

        /// <summary>
        /// Add a line to the current collection of Lines drawn within the current Game State. 
        /// To be called when a player requests a valid line to be drawn on their turn.
        /// </summary>
        public void AddLine (Line line)
        {
            _lines.Add(line);
        }

    }

}
