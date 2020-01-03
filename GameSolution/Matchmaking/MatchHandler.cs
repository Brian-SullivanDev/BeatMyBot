using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBuilderEngine;
using static AIBuilderEngine.WorkflowUtilities;
using GameEngine;
using static GameEngine.Utilities;
using static GameEngine.DatabaseSubstitute;
using static AIBuilderEngine.DatabaseSubstitute;

namespace Matchmaking
{

    public class MatchHandler
    {

        private Player _firstPlayer;

        public Player FirstPlayer
        {
            get
            {
                return _firstPlayer;
            }
        }

        private Player _secondPlayer;

        public Player SecondPlayer
        {
            get
            {
                return _secondPlayer;
            }
        }

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

        private StringBuilder _gameLog;

        public string GameLog
        {
            get
            {
                return _gameLog.ToString();
            }
        }

        private GameState _state;

        public GameState State
        {
            get
            {
                return _state;
            }
        }

        private BaseClass firstPlayerClass = null;
        private BaseClass secondPlayerClass = null;

        /// <summary>
        /// The Match Handler takes two player IDs and a height and width for a game and then handlings the match itself
        /// </summary>
        public MatchHandler(int firstPlayerID, int secondPlayerID, int height, int width)
        {

            _firstPlayer = new Player(firstPlayerID);
            _secondPlayer = new Player(secondPlayerID);
            _height = height;
            _width = width;
            _gameLog = new StringBuilder();
            _state = new GameState(height, width);

            HandleDynamicPlayerObjects();

        }

        /// <summary>
        /// Use reflection to instantiate an instance of each player's class for their object and then store those dynamic references for the main game handling
        /// </summary>
        private void HandleDynamicPlayerObjects()
        {

            try
            {
                
                var firstPlayerType = Type.GetType(_firstPlayer.ObjectName, true, true);
                var secondPlayerType = Type.GetType(_secondPlayer.ObjectName, true, true);
                
                firstPlayerClass = (BaseClass)(Activator.CreateInstance(firstPlayerType, new object[] {
                    _state,
                    _firstPlayer.ID
                }));
                secondPlayerClass = (BaseClass)(Activator.CreateInstance(secondPlayerType, new object[] {
                    _state,
                    _secondPlayer.ID
                }));

            }
            catch (Exception ex)
            {

                AddToGameLog("(ex) - " + ex.Message);

            }

        }

        /// <summary>
        /// Prompt a player, by ID, to take their turn through its custom class
        /// </summary>
        public int ProcessNextTurn(int playerID)
        {

            bool playSwitchesHands = true;

            int turnAttempts = 0;

            while (turnAttempts < 10)
            {

                RequestedLine requestedNextMove = null;

                turnAttempts++;

                if (playerID == _firstPlayer.ID)
                {

                    requestedNextMove = firstPlayerClass.MakeNextMove();

                }
                else
                {

                    requestedNextMove = secondPlayerClass.MakeNextMove();

                }

                if (!(LineIsValid(requestedNextMove, _state)))
                {
                    AddToGameLog($"player with ID: {playerID} failed to issue a valid move.  {10 - turnAttempts} attempts remaining.");
                    continue;
                }
                else
                {
                    if (LineWillCloseABox(_state, requestedNextMove) == true)
                    {
                        playSwitchesHands = false;
                    }
                    Line nextMoveLine = new Line(requestedNextMove.Start, requestedNextMove.End, playerID);
                    _state.AddLine(nextMoveLine);
                    AddToGameLog($"player with ID: {playerID} added a line from {nextMoveLine.Start} to {nextMoveLine.End}");
                    break;
                }

            }

            firstPlayerClass.ProcessLastMove(_state);
            secondPlayerClass.ProcessLastMove(_state);

            if (playSwitchesHands == true)
            {
                playerID = DetermineNextPlayerID(playerID, _firstPlayer.ID, _secondPlayer.ID);
            }

            return playerID;

        }

        /// <summary>
        /// until all lines are drawn, prompt players in the appropriate order to take their respective turns
        /// </summary>
        public void RunMatch()
        {

            int turnIndex = 0;

            int totalLines = (_state.Height * (_state.Width - 1)) + (_state.Width * (_state.Height - 1));

            int nextTurnPlayerID = _firstPlayer.ID;

            while (turnIndex < totalLines)
            {

                ++turnIndex;

                nextTurnPlayerID = ProcessNextTurn(nextTurnPlayerID);

            }

        }

        /// <summary>
        /// get the ID of the player to go next based on the current player's ID
        /// </summary>
        private int DetermineNextPlayerID(int currentID, int firstID, int secondID)
        {

            if (currentID == firstID)
            {
                return secondID;
            }
            else
            {
                return firstID;
            }

        }

        /// <summary>
        /// Internal function to log a provided statement.  In this case, the log is kept as an internal stringbuilder that can be written to a string
        /// </summary>
        private void AddToGameLog(string logStatement)
        {

            _gameLog.AppendLine(logStatement);

        }

    }

}
