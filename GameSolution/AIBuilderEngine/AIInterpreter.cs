using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using static AIBuilderEngine.WorkflowUtilities;
using static GameEngine.Utilities;

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

        private StepResult lastResult;

        private bool completedWorkflow = false;

        private GameState _state;

        public GameState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The AIInterpreter object is responsible for managing a workflow for an AI class with the provided current state.
        /// This object is responsible for determining the next RequestedLine for an AI player via the workflow provided.
        /// </summary>
        public AIInterpreter(LogicalWorkflow workflow, GameState state)
        {
            _variables = new Dictionary<string, object>();
            _workflow = workflow;
            _state = state;
            completedWorkflow = false;
            currentStep = null;
        }

        /// <summary>
        /// Runs through the workflow and attempts to determine the Line for the player to request to be drawn next in the game.
        /// Returns True if a valid Line was requested and False otherwise.
        /// </summary>
        public bool Interpret()
        {

            bool foundValidLine = false;

            try
            {

                int stepsTaken = 0;

                bool keepInterpretting = true;

                while (keepInterpretting == true && stepsTaken < 1000)
                {

                    ++stepsTaken;

                    keepInterpretting = InterpretNextStep();

                }

                if (LineIsValid(ResultLine, _state)) {

                    foundValidLine = true;

                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return foundValidLine;

        }

        /// <summary>
        /// Determine what the next step for processing is going to be
        /// </summary>
        private LogicalStep GetNextStep ()
        {

            LogicalStep nextStep = null;

            if (currentStep == null)
            {
                nextStep = _workflow.FirstStep;
            }
            else
            {
                nextStep = GetStepByPreviousResult(currentStep);
            }

            return nextStep;

        }

        /// <summary>
        /// Determine which path to take for the next step based on the result returned from the current step
        /// </summary>
        private LogicalStep GetStepByPreviousResult (LogicalStep step)
        {

            LogicalStep nextStep = null;

            try
            {

                if (step == null)
                {
                    nextStep = _workflow.FirstStep;
                }
                else
                {
                    switch(lastResult)
                    {

                        case StepResult.True:
                            nextStep = step.NextStepTrue;
                            break;
                        case StepResult.False:
                            nextStep = step.NextStepFalse;
                            break;
                        case StepResult.Else:
                            nextStep = step.NextStepElse;
                            break;

                    }
                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return nextStep;

        }

        /// <summary>
        /// Take the next step in processing and update the private variables accordingly.
        /// </summary>
        /// <returns>True if there is another step after the current step (to prompt the engine for further processing)</returns>
        private bool InterpretNextStep()
        {

            bool anotherStepFollows = true;

            try
            {

                LogicalStep nextStep = GetNextStep();

                StepResult stepResult = StepResult.False;

                switch (nextStep.AIFunction)
                {

                    case AIFunction.CheckNextOrdinalLine:
                        stepResult = Process_CheckNextOrdinalLine();
                        break;
                    case AIFunction.CheckNextOrdinalPoint:
                        break;
                    case AIFunction.CreateVariable:
                        break;
                    case AIFunction.InterpretVariable:
                        break;
                    case AIFunction.ModifyVariable:
                        break;

                }

                lastResult = stepResult;

                currentStep = nextStep;

                anotherStepFollows = (!(GetStepByPreviousResult(currentStep) == null));

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return anotherStepFollows;

        }

        /// <summary>
        /// Process the interpretation of the CheckNextOrdinalLine Logical Function.
        /// Update the appropriate AIInterpreter fields and return the StepResult.
        /// </summary>
        private StepResult Process_CheckNextOrdinalLine()
        {

            StepResult stepResult = StepResult.False;

            try
            {

                AIResult<RequestedLine> functionResult = CheckNextOrdinalLine(_state);
                stepResult = functionResult.Result;
                if (stepResult == StepResult.True)
                {
                    _resultLine = functionResult.Value;
                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return stepResult;

        }

    }

}
