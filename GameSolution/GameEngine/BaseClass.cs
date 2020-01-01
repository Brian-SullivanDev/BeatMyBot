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

        public void ProcessLastMove(GameState updatedState)
        {

            _state = updatedState;

        }

        public abstract RequestedLine MakeNextMove();

        public BaseClass (GameState initialState, int playerID)
        {

            _state = initialState;
            _playerID = playerID;

        }

    }

}
