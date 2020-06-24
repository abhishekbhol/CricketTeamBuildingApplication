using System;
using System.Collections.Generic;
using System.Text;

namespace CricketTeamBuildingApplication
{
    public class User
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public int budget { get; set; }
        public List<Player> team { get; set; }
        public bool matchReady { get; set; }

        public User(string userName)
        {
            this.userName = userName;
            userId = Guid.NewGuid();
            team = new List<Player>();
            matchReady = false;
            budget = 100;
        }

        public int TotalPoints()
        {
            var totalPoints = 0;

            foreach(var player in team)
            {
                totalPoints += player.score;
            }

            return totalPoints;
        }
    }
}
