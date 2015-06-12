using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using NumbersGameWebAPI.Models;
using ScottLogic.NumbersGame;
using ScottLogic.NumbersGame.Game;

namespace NumbersGameWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Generate our games
            int gameId = 0;
            for (int n = 0; n < 5; n++)
            {
                for (int big = 0; big <= 4; big++)
                {
                    int[] values;
                    int target;
                    if (GameGenerator.GenerateCountdownGame(big, out values, out target))
                    {
                        gameId++;
                        var g = new Definition { GameId = gameId, BigNumbers = big, StartingValues = values, Target = target };
                        GameDefinition.Repository.Add(g);

                    }
                }
            }

        }
    }
}
