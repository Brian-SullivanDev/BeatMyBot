using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace AIBuilderEngine
{

    public class AIInterpreter
    {

        private Dictionary<string, object> _variables;

        public Dictionary<string, object> Variables
        {
            get
            {
                return _variables;
            }
        }

        private LogicalWorkflow _workflow;

        public LogicalWorkflow Workflow
        {
            get
            {
                return _workflow;
            }
        }

        private RequestedLine _resultLine;

        public RequestedLine ResultLine
        {
            get
            {
                return _resultLine;
            }
        }

        private LogicalStep currentStep;

        private bool completedWorkflow = false;

        public AIInterpreter(Dictionary<string, object> variables, LogicalWorkflow workflow)
        {
            _variables = variables;
            _workflow = workflow;
            completedWorkflow = false;
        }

        public bool Interpret()
        {

            return false;

        }

        private bool InterpretNextStep()
        {

            return false;

        }

    }

}
