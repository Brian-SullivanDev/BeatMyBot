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

        /// <summary>
        /// The AI Result object encapsulates a generic value and a StepResult property into a single reusable object
        /// </summary>
        /// <param name="value">generic value of the Type specified</param>
        /// <param name="result">StepResult value that categorizes the finished state of the step (True, False, or Else)</param>
        public AIResult (T value, StepResult result) {

            _value = value;
            _result = result;

        }

    }

}
