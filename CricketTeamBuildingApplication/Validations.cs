using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CricketTeamBuildingApplication
{
    public class Validations
    {
        public static readonly int minBatsmanNeeded = 3;
        public static readonly int minBowlerNeeded = 3;
        public static readonly int minWeeketKeeperNeeded = 1;
        public static readonly int totalTeamSizeAllowed = 11;

        public static ValidationResult CheckValidationsAssignScore(int score)
        {
            if(score < 0)
            {
                return new ValidationResult
                {
                    success = false,
                    result = "score can not be negative"
                };
            }
            return new ValidationResult
            {
                success = true,
                result = "Sucess"
            };
        }

        public static ValidationResult CheckValidationsAddPlayer(User u, Player p)
        {
            var teamSize = u.team.Count;

            if (teamSize >= 11)
            {
                return new ValidationResult
                {
                    success = false,
                    result = "Team size full"
                };
            }

            if (u.budget < p.cost)
            {
                return new ValidationResult
                {
                    success = false,
                    result = "Not enough budget"
                };
            }

            var playerExists = u.team.Exists(a => a.playerId == p.playerId);

            if(playerExists)
            {
                return new ValidationResult
                {
                    success = false,
                    result = "Player Already exists"
                };
            }

            u.team.Add(p);

            var totalBatsman = u.team.Where(x => x.type == PlayerType.Batsman).Count();
            var totalBowler = u.team.Where(x => x.type == PlayerType.Bowler).Count();
            var totalWicketKeeper = u.team.Where(x => x.type == PlayerType.WicketKeeper).Count();

            
            if(totalBatsman >= minBatsmanNeeded && totalBowler >= minBowlerNeeded && totalWicketKeeper >= minWeeketKeeperNeeded)
            {
                return new ValidationResult
                {
                    success = true,
                    result = "Sucess"
                };
            }
            else
            {
                var batsmanNeeded = 0;
                var bowlerNeeded = 0;
                var wicketkeeperNeeded = 0;

                if (totalBatsman < minBatsmanNeeded)
                {
                    batsmanNeeded = minBatsmanNeeded - totalBatsman;
                }
                if (totalBowler < minBowlerNeeded)
                {
                    bowlerNeeded = minBowlerNeeded - totalBowler;
                }
                if (totalWicketKeeper < minWeeketKeeperNeeded)
                {
                    wicketkeeperNeeded = minWeeketKeeperNeeded - totalWicketKeeper;
                }

                if(batsmanNeeded + bowlerNeeded + wicketkeeperNeeded >= (totalTeamSizeAllowed- teamSize))
                {
                    u.team.Remove(p);
                    return new ValidationResult
                    {
                        success = false,
                        result = "Add Different type of player"
                    };
                }
            }


            return new ValidationResult
            {
                success = true,
                result = "Sucess"
            };

        }
    }

    public class ValidationResult
    {
        public bool success { get; set; }
        public string result { get; set; }
    }
}
