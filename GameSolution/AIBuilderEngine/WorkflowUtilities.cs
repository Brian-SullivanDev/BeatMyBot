using System;
using System.Collections.Generic;
using System.Text;
using GameEngine;
using static GameEngine.Utilities;
using static AIBuilderEngine.WorkflowUtilities;

namespace AIBuilderEngine
{

    public class WorkflowUtilities
    {

        /// <summary>
        /// Enumeration for possible AI Functions to use wihtin a Logical Step
        /// </summary>
        public enum AIFunction
        {
            CreateVariable,
            ModifyVariable,
            InterpretVariable,
            CheckNextOrdinalPoint,
            CheckNextOrdinalLine

        }

        /// <summary>
        /// Enumeration for possible Result paths logic can take during processing of an AI Function within a Logical Step
        /// </summary>
        public enum StepResult
        {
            True,
            False,
            Else
        }

        /// <summary>
        /// Return the next available line ordinally.  StepResult is True if a line was returned and False otherwise (else if exception was thrown)
        /// </summary>
        /// <param name="state">current game state</param>
        public static AIResult<RequestedLine> CheckNextOrdinalLine (GameState state)
        {

            StepResult returnStepResult = StepResult.False;
            RequestedLine returnLine = null;

            try
            {

                returnLine = FindFirstAvailableLine(state);

                if (returnLine != null)
                {
                    returnStepResult = StepResult.True;
                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
                returnLine = null;
                returnStepResult = StepResult.Else;
            }

            AIResult<RequestedLine> returnResult = new AIResult<RequestedLine>(returnLine, returnStepResult);

            return returnResult;

        }

    }

}
