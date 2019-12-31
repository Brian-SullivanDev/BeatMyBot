using System;
using System.Collections.Generic;
using System.Text;
using static AIBuilderEngine.WorkflowUtilities;

namespace AIBuilderEngine
{

    public class AIResult<T>
    {

        private T _value;

        public T Value
        {
            get
            {
                return _value;
            }
        }

        private StepResult _result;

        public StepResult Result
        {
            get
            {
                return _result;
            }
        }

        public AIResult (T value, StepResult result) {

            _value = value;
            _result = result;

        }

    }

}
