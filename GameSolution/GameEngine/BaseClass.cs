using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{

    public abstract class BaseClass
    {

        private GameState _state;

        public GameState State
        {
            get
            {
                return _state;
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

        /// <summary>
        /// This function is functional.  Anything that overrides this should reference the base logic and add more.  
        /// Make sure that state is maintained or you may find it difficult to have a functional object
        /// </summary>
        public void ProcessLastMove(GameState updatedState)
        {

            _state = updatedState;

        }

        /// <summary>
        /// Override this empty function with the logic that will determine which Line you wish to draw each turn based on the Game State
        /// </summary>
        public abstract RequestedLine MakeNextMove();

        /// <summary>
        /// This Base Class is not functional alone.  It must be inherited and have its ProcessLastMove function implemented properly.
        /// </summary>
        public BaseClass (GameState initialState, int playerID)
        {

            _state = initialState;
            _playerID = playerID;

        }

    }

}
