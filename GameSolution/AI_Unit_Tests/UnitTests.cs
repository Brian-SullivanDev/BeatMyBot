using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GameEngine.Utilities;
using static AIBuilderEngine.WorkflowUtilities;
using GameEngine;
using AIBuilderEngine;

namespace AI_Unit_Tests
{

    [TestClass]
    public class AIInterpreter_Function_Tests
    {

        [TestMethod]
        public void Test_CheckNextOrdinalLine()
        {

            GameState state = new GameState(10, 10);

            LogicalStep testStep = new LogicalStep(null, null, null, AIFunction.CheckNextOrdinalLine);

            LogicalWorkflow workflow = new LogicalWorkflow(testStep);

            AIInterpreter interpreter = new AIInterpreter(workflow, state);

            interpreter.Interpret();

            RequestedLine result = interpreter.ResultLine;

            if (LineIsValid(result, state) != true)
            {
                Assert.Fail("CheckNextOrdinalLine returned an invalid next move.");
            }

        }

    }

}
