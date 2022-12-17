using GenericDaoLibrary;
using MiningDataAccessLayer.Model;
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
            string id = ShortUIDTool.CreateShortId();
            string gameName = "Yukon Ho!";

            //act
            MiningGame game = new MiningGame();
            game.Id = id;
            game.Name = gameName;

            //assert
            Assert.AreEqual(id, game.Id, "IDs differed");
            Assert.AreEqual(gameName, game.Name, "The name differed");
        }

        [Test]
        public void TeamObjectProperties()
        {
            //arrange
            string id = ShortUIDTool.CreateShortId();
            string teamName = "Mibo Miners!";
            int accountBalance = 199;
            MapSquare q1 = new MapSquare() { X = 2, Y = 4, Value = 42 };

            //act
            Team team = new ();
            team.Id = id;
            team.KnownMapSquares.Add(q1);
            team.AccountBalance = accountBalance;
            team.Name = teamName;

            //assert
            Assert.AreEqual(id, team.Id, "The ID differed");
            Assert.AreEqual(teamName, team.Name, "The name differed");
            Assert.AreEqual(accountBalance, team.AccountBalance, "The account balance differed");
            Assert.AreEqual(q1.X, team.KnownMapSquares[0].X, "The map square differed");

        }
    }
}