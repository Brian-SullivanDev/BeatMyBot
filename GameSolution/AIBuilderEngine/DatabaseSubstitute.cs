using System;
using System.Collections.Generic;
using System.Text;
using GameEngine;
using static GameEngine.Utilities;
using static AIBuilderEngine.WorkflowUtilities;

namespace AIBuilderEngine
{

    public class DatabaseSubstitute
    {

        private enum WorkflowKeys
        {
            DemoWorkflow_Simple = 0,
            DemoWorkflow_Complex = 1
        }

        /// <summary>
        /// Hard-coded simple workflow to always fetch the next available Ordinal line
        /// </summary>
        private static LogicalWorkflow GetSimpleDemoWorkflow ()
        {

            LogicalWorkflow workflow = null;

            try
            {

                LogicalStep firstStep = new LogicalStep(null, null, null, WorkflowUtilities.AIFunction.CheckNextOrdinalLine);

                workflow = new LogicalWorkflow(firstStep);

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return workflow;

        }

        /// <summary>
        /// Placeholder for database logic that provides a lookup of a Workflow that is tied to a player AI by ID
        /// </summary>
        public static LogicalWorkflow LookupWorkflowByPlayerID (int playerID)
        {

            LogicalWorkflow workflow = null;

            try
            {

                switch (playerID)
                {

                    case (int)WorkflowKeys.DemoWorkflow_Simple:
                        workflow = GetSimpleDemoWorkflow();
                        break;
                    case (int)WorkflowKeys.DemoWorkflow_Complex:
                        break;

                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return workflow;

        }

    }

}
