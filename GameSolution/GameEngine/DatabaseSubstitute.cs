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
                    return "GameEngine.DemoEngineClass1";
                }
                else if (playerID == 2)
                {
                    return "GameEngine.DemoEngineClass1";
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
