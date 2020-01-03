using System;
using System.Collections.Generic;
using System.Text;
using static GameEngine.DatabaseSubstitute;

namespace GameEngine
{

    public class Player
    {

        private int _id;

        public int ID
        {
            get
            {
                return _id;
            }
        }

        private string _objectName;

        public string ObjectName
        {
            get
            {
                return _objectName;
            }
        }

        /// <summary>
        /// The Player object encapsulates the ID of the player and a String reference to the Type of the player's AI logic
        /// </summary>
        public Player (int playerID)
        {

            _id = playerID;
            _objectName = LookupPlayerByID(playerID);

        }

    }

}
