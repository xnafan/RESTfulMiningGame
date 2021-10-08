using MiningClassLibrary;
using NUnit.Framework;
using System;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GameObjectProperties()
        {
            //arrange
            Guid id = Guid.NewGuid();
            string gameName = "Yukon Ho!";
            int areaHeight = 6;
            int areaWidth = 12;
            int seed = 53;

            //act
            Game game = new Game();
            game.Id = id;
            game.Name = gameName;
            game.GameAreaHeightInQuadrants = areaHeight;
            game.GameAreaWidthInQuadrants = areaWidth;
            game.Seed = seed;

            //assert
            Assert.AreEqual(id, game.Id, "IDs differed");
            Assert.AreEqual(gameName, game.Name, "The name differed");
            Assert.AreEqual(areaHeight, game.GameAreaHeightInQuadrants, "The height differed");
            Assert.AreEqual(areaWidth, game.GameAreaWidthInQuadrants, "The width differed");
            Assert.AreEqual(seed, game.Seed, "The seed differed");

        }

        [Test]
        public void TeamObjectProperties()
        {
            //arrange
            Guid id = Guid.NewGuid();
            string teamName = "Mibo Miners!";
            int accountBalance = 199;
            Quadrant q1 = new Quadrant() { X = 2, Y = 4, Content = 42 };

            //act
            Team team = new ();
            team.Id = id;
            team.KnownQuadrants.Add(q1);
            team.AccountBalance = accountBalance;
            team.Name = teamName;

            //assert
            Assert.AreEqual(id, team.Id, "The ID differed");
            Assert.AreEqual(teamName, team.Name, "The name differed");
            Assert.AreEqual(accountBalance, team.AccountBalance, "The account balance differed");
            Assert.AreEqual(q1.X, team.KnownQuadrants[0].X, "The quadrant differed");

        }
    }
}