using System;
using System.Collections.Generic;
using System.Text;
using static GameEngine.Utilities;

namespace GameEngine
{

    public class DatabaseSubstitute
    {

        public static string LookupPlayerByID (int playerID)
        {

            string objectName = "";

            try
            {

                if (playerID == 1)
                {
                    return "GameEngine.DemoEngineClass1, GameEngine";
                }
                else if (playerID == 2)
                {
                    return "GameEngine.DemoEngineClass1, GameEngine";
                }
                else if (playerID == 3)
                {
                    return "GameEngine.DemoEngineClass2, GameEngine";
                }
                else if (playerID == 4)
                {
                    return "GameEngine.DemoEngineClass2, GameEngine";
                }
                else if (playerID == 5)
                {
                    return "AIBuilderEngine.AIClass, AIBuilderEngine";
                }
                else if (playerID == 6)
                {
                    return "AIBuilderEngine.AIClass, AIBuilderEngine";
                }

            }
            catch (Exception ex)
            {
                LogError("(ex) - " + ex.Message);
            }

            return objectName;

        }

    }

}
