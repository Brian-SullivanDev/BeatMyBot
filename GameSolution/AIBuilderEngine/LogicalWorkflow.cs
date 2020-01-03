using System;
using System.Collections.Generic;
using System.Text;

namespace AIBuilderEngine
{

    public class LogicalWorkflow
    {

        private LogicalStep _firstStep;

        public LogicalStep FirstStep
        {
            get
            {
                return _firstStep;
            }
        }

        /// <summary>
        /// The Logical Workflow object points to the first Logical Step and allows an entry point into processing an AI
        /// </summary>
        public LogicalWorkflow (LogicalStep firstStep)
        {
            _firstStep = firstStep;

        }

    }

}
