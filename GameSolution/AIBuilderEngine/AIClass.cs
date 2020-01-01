using System;
using System.Collections.Generic;
using System.Text;
using GameEngine;
using static GameEngine.Utilities;
using AIBuilderEngine;
using static AIBuilderEngine.WorkflowUtilities;
using static AIBuilderEngine.DatabaseSubstitute;

namespace AIBuilderEngine
{

    public class AIClass : BaseClass
    {

        private LogicalWorkflow _workflow;

        public LogicalWorkflow Workflow
        {
            get
            {
                return _workflow;
            }
        }

        public AIClass(GameState initialState, int playerID) : base(initialState, playerID)
        {

            _workflow = LookupWorkflowByPlayerID(playerID);

        }

        /// <summary>
        /// overrides the abstract provided in the base class.  This is the entry point from the calling program that allows us to customize our class and make it our own
        /// </summary>
        /// <returns>Next desired move in the game</returns>
        public override RequestedLine MakeNextMove()
        {

            RequestedLine requestedLine = null;

            try
            {

                AIInterpreter interpreter = new AIInterpreter(_workflow, State);

                requestedLine = FindFirstAvailableLine(State);

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return requestedLine;

        }

    }

}
