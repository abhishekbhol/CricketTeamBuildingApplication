using System;
using System.Collections.Generic;
using System.Text;

namespace CricketTeamBuildingApplication
{
    public class TeamBuildingService
    {
        public static List<Player> playerPool;
        public static List<User> userList;

        public static void setup()
        {
            playerPool = new List<Player>();
            userList = new List<User>();

            userList.Add(new User("Abhishek"));
            FillPlayerPool();
        }

        public static void FillPlayerPool()
        {
            int i = 0;

            playerPool.Add(new Player("sachin", PlayerType.Batsman, 10));
            playerPool.Add(new Player("sehwag", PlayerType.Batsman, 11));
            playerPool.Add(new Player("virat", PlayerType.Batsman, 9));
            playerPool.Add(new Player("yuvraj", PlayerType.Batsman, 9));
            playerPool.Add(new Player("gayle", PlayerType.Batsman, 50));

            playerPool.Add(new Player("zaheer", PlayerType.Bowler, 12));
            playerPool.Add(new Player("bumrah", PlayerType.Bowler, 11));
            playerPool.Add(new Player("yadav", PlayerType.Bowler, 8));
            playerPool.Add(new Player("jadeja", PlayerType.Bowler, 50));


            playerPool.Add(new Player("dhoni", PlayerType.WicketKeeper, 12));
            playerPool.Add(new Player("pant", PlayerType.WicketKeeper, 8));


            while (i < 50)
            {
                playerPool.Add(new Player("player"+ i.ToString(), PlayerType.Batsman, 9));
                i++;
            }

            while (i < 90)
            {
                playerPool.Add(new Player("player" + i.ToString(), PlayerType.Bowler, 7));
                i++;
            }

            while (i < 101)
            {
                playerPool.Add(new Player("player" + i.ToString(), PlayerType.WicketKeeper, 9));
                i++;
            }
        }

        public static int CheckTotalPoint(User user)
        {
            return user.TotalPoints();
        }

        public static ValidationResult AddPlayer(User user, Player player)
        {

            var result = Validations.CheckValidationsAddPlayer(user, player);

            if(result.success)
            {
                user.budget -= player.cost;

                if(user.team.Count == 11)
                {
                    user.matchReady = true;
                }
            }

            return result;
        }

        public static ValidationResult AssignScore(Player p , int score)
        {
            var result = Validations.CheckValidationsAssignScore(score);

            if(result.success)
            {
                p.score = score;
            }

            return result;
        }


    }
}
