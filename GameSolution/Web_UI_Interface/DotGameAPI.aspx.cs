using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameEngine;
using static GameEngine.Utilities;
using Newtonsoft.Json;
using Matchmaking;

namespace Web_UI_Interface
{
    public partial class DotGameAPI : System.Web.UI.Page
    {

        public string GetParameterValue(string parameterName)
        {

            string parameterValue = "";

            try
            {

                parameterValue = Request.QueryString[parameterName];

            }
            catch (Exception)
            {
                
            }

            return parameterValue;

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                int firstPlayerID = CheckNullInt(GetParameterValue("PID1"));
                int secondPlayerID = CheckNullInt(GetParameterValue("PID2"));

                MatchHandler gameEngine = new MatchHandler(firstPlayerID, secondPlayerID, 10, 10);

                gameEngine.RunMatch();

                string JSONLog = JsonConvert.SerializeObject(gameEngine.State.Lines);

                Response.Clear();
                Response.Write(JSONLog);
                Response.End();

            }
            catch (Exception ex)
            {
                
            }

        }

    }
}