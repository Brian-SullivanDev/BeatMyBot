using System;
using System.Collections.Generic;
using System.Text;
using static AIBuilderEngine.WorkflowUtilities;

namespace AIBuilderEngine
{

    public class LogicalStep
    {

        private LogicalStep _nextStepTrue;

        public LogicalStep NextStepTrue
        {
            get
            {
                return _nextStepTrue;
            }
        }

        private LogicalStep _nextStepFalse;

        public LogicalStep NextStepFalse
        {
            get
            {
                return _nextStepFalse;
            }
        }

        private LogicalStep _nextStepElse;

        public LogicalStep NextStepElse
        {
            get
            {
                return _nextStepElse;
            }
        }

        private AIFunction _function;

        public AIFunction AIFunction
        {
            get
            {
                return _function;
            }
        }

        /// <summary>
        /// Logical Step objects reference an individual step within a workflow and points to other Logical Steps to process after this one 
        /// depending on the finished state of the logic that processes this step.  Logical flow ends when a step leads down a path 
        /// that it has not mapped a next step for.
        /// </summary>
        /// <param name="nextStepTrue">Logical Step to process next if this step results in True</param>
        /// <param name="nextStepFalse">Logical Step to process next if this step results in False</param>
        /// <param name="nextStepElse">Logical Step to process next if this step results in Else</param>
        /// <param name="myFunction">AIFunction value via enumeration</param>
        public LogicalStep (LogicalStep nextStepTrue, LogicalStep nextStepFalse, LogicalStep nextStepElse,
            AIFunction myFunction)
        {
            _nextStepTrue = nextStepTrue;
            _nextStepFalse = nextStepFalse;
            _nextStepElse = nextStepElse;
            _function = myFunction;
        }

    }

}
