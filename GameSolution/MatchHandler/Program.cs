using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace MatchHandler
{

    class Program
    {

        static void Main(string[] args)
        {

            int playerID1 = 1;
            int playerID2 = 2;

            BaseClass player1Class = new DemoEngineClass1();
            BaseClass player2Class = new DemoEngineClass1();

            int turnIndex = 0;

            RequestedLine requestedNextMove = null;

            while ( turnIndex < 20 )
            {

                requestedNextMove = null;

                turnIndex++;

                int turnAttempts = 0;

                while (turnAttempts < 10 && true)
                {

                    if (turnIndex % 2 == 0)
                    {

                        requestedNextMove = player1Class.MakeNextMove();

                    }
                    else
                    {

                        requestedNextMove = player2Class.MakeNextMove();

                    }

                }

            }

        }

    }

}
