using NUnit.Framework;
using CricketTeamBuildingApplication;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TeamBuildingService.setup();
        }

        [Test]
        public void TestBudget()
        {
            var abhishek = TeamBuildingService.userList[0];
            var jadeja = TeamBuildingService.playerPool.Where(a => a.name == "jadeja").FirstOrDefault();
            var gayle = TeamBuildingService.playerPool.Where(a => a.name == "gayle").FirstOrDefault();
            var sehwag = TeamBuildingService.playerPool.Where(a => a.name == "sehwag").FirstOrDefault();

            var res = TeamBuildingService.AddPlayer(abhishek, jadeja);

            Assert.IsTrue(res.success);

            res = TeamBuildingService.AddPlayer(abhishek, gayle);

            Assert.IsTrue(res.success);

            res = TeamBuildingService.AddPlayer(abhishek, sehwag);

            Assert.IsFalse(res.success);
            Assert.AreEqual(res.result, "Not enough budget");

        }

        [Test]
        public void TestHappyCaseAndTeamSizeFull()
        {
            var abhishek = TeamBuildingService.userList[0];
            var players = TeamBuildingService.playerPool;
            ValidationResult res = Add11Players(abhishek, players);

            Assert.IsTrue(res.success);
            Assert.AreEqual(1, abhishek.budget);

            res = TeamBuildingService.AddPlayer(abhishek, players[66]);

            Assert.IsFalse(res.success);
            Assert.AreEqual(res.result, "Team size full");

        }

        [Test]
        public void TestOnlyBowlers()
        {
            var abhishek = TeamBuildingService.userList[0];
            var players = TeamBuildingService.playerPool;

            ValidationResult res = TryAdding8Bowlers(abhishek, players);

            Assert.IsFalse(res.success);
            Assert.AreEqual(res.result, "Add Different type of player");

        }

        [Test]
        public void TestDuplicatePlayer()
        {
            var abhishek = TeamBuildingService.userList[0];
            var players = TeamBuildingService.playerPool;

            var res = TeamBuildingService.AddPlayer(abhishek, players[0]);
            res = TeamBuildingService.AddPlayer(abhishek, players[0]);

            Assert.IsFalse(res.success);
            Assert.AreEqual(res.result, "Player Already exists");

        }

        private static ValidationResult TryAdding8Bowlers(User abhishek, System.Collections.Generic.List<Player> players)
        {
            var res = TeamBuildingService.AddPlayer(abhishek, players[63]);
            res = TeamBuildingService.AddPlayer(abhishek, players[64]);
            res = TeamBuildingService.AddPlayer(abhishek, players[65]);
            res = TeamBuildingService.AddPlayer(abhishek, players[64]);
            res = TeamBuildingService.AddPlayer(abhishek, players[65]);
            res = TeamBuildingService.AddPlayer(abhishek, players[64]);
            res = TeamBuildingService.AddPlayer(abhishek, players[65]);
            res = TeamBuildingService.AddPlayer(abhishek, players[64]);

            return res;
        }

        private static ValidationResult Add11Players(User abhishek, System.Collections.Generic.List<Player> players)
        {
            var sachin = TeamBuildingService.playerPool.Where(a => a.name == "sachin").FirstOrDefault();
            var virat = TeamBuildingService.playerPool.Where(a => a.name == "virat").FirstOrDefault();
            var sehwag = TeamBuildingService.playerPool.Where(a => a.name == "sehwag").FirstOrDefault();
            var yuvraj = TeamBuildingService.playerPool.Where(a => a.name == "yuvraj").FirstOrDefault();

            var yadav = TeamBuildingService.playerPool.Where(a => a.name == "yadav").FirstOrDefault();
            var bumrah = TeamBuildingService.playerPool.Where(a => a.name == "bumrah").FirstOrDefault();
            var zaheer = TeamBuildingService.playerPool.Where(a => a.name == "zaheer").FirstOrDefault();

            var pant = TeamBuildingService.playerPool.Where(a => a.name == "pant").FirstOrDefault();


            var res = TeamBuildingService.AddPlayer(abhishek, sachin);

            res = TeamBuildingService.AddPlayer(abhishek, sehwag);
            res = TeamBuildingService.AddPlayer(abhishek, virat);
            res = TeamBuildingService.AddPlayer(abhishek, yuvraj);
            res = TeamBuildingService.AddPlayer(abhishek, yadav);
            res = TeamBuildingService.AddPlayer(abhishek, bumrah);
            res = TeamBuildingService.AddPlayer(abhishek, zaheer);
            res = TeamBuildingService.AddPlayer(abhishek, pant);

            res = TeamBuildingService.AddPlayer(abhishek, players[63]);
            res = TeamBuildingService.AddPlayer(abhishek, players[64]);
            res = TeamBuildingService.AddPlayer(abhishek, players[65]);

            return res;
        }
    }
}