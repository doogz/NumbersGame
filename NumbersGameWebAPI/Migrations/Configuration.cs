using NumbersGameWebAPI.Models;

namespace NumbersGameWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NumbersGameWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NumbersGameWebAPI.Models.NumbersGameWebAPIContext";
        }

        protected override void Seed(NumbersGameWebAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Generate some games to seed the database
            int gameId = 0;
            for (int n = 0; n < 5; n++) // 5 of each kind
            {
                for (int big = 0; big <= 4; big++)
                {

                    int target;
                    int[] values;
                    if (ScottLogic.NumbersGame.GameGenerator.GenerateCountdownGame(big, out values, out target))
                    {
                        ++gameId;
                        var game = new Game {GameId = gameId, BigNumbers = big, InitialValues = values, Target = target};
                        context.Games.AddOrUpdate(game);
                    }
                }
            }
        }
    }
}
