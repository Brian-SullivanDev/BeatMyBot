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

        private bool _reachedLastStep;

        public LogicalWorkflow (LogicalStep firstStep)
        {
            _firstStep = firstStep;

        }

    }

}
