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

        private object[] _variables;

        public object[] Variables
        {
            get
            {
                return _variables;
            }
        }

        public LogicalStep (LogicalStep nextStepTrue, LogicalStep nextStepFalse, LogicalStep nextStepElse,
            AIFunction myFunction, object[] variables)
        {
            _nextStepTrue = nextStepTrue;
            _nextStepFalse = nextStepFalse;
            _nextStepElse = nextStepElse;
            _function = myFunction;
            _variables = variables;
        }

    }

}
