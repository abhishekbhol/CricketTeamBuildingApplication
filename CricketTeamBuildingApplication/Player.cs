using System;
using System.Collections.Generic;
using System.Text;

namespace CricketTeamBuildingApplication
{
    public class Player
    {
        public Guid playerId { get; set; }
        public string name { get; set; }
        public PlayerType type { get; set; }
        public int cost { get; set; }

        public int score { get; set; }

        public Player(string name, PlayerType type, int cost)
        {
            this.playerId = Guid.NewGuid();
            this.name = name;
            this.type = type;
            this.cost = cost;
            this.score = 0;
        }
    }

    public enum PlayerType
    {
        Batsman,
        Bowler,
        WicketKeeper,
        Allrounder,
    }
}
