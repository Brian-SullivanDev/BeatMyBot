using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{

    public class Point
    {

        private int _x;

        public int X
        {
            get
            {
                return _x;
            }
        }

        private int _y;

        public int Y
        {
            get
            {
                return _y;
            }
        }

        public Point (int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override bool Equals(object obj)
        {

            var other = obj as Point;

            return other.X == this.X && other.Y == this.Y;

        }

        public static bool operator == (Point thisPoint, Point other)
        {

            try
            {
                return thisPoint.X == other.Y && thisPoint.Y == other.Y;
            }
            catch (Exception)
            {
                
            }

            return false;

        }

        public static bool operator != (Point thisPoint, Point other)
        {

            try
            {
                if ( thisPoint.X == other.Y && thisPoint.Y == other.Y )
                {
                    return false;
                }
            }
            catch (Exception)
            {

            }

            return true;

        }
        

    }

}
