using MiningApi.Dtos;
using MiningApi.DTOs.Converters;
using MiningClassLibrary;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestProject
{
    public class ConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GameConverterToDto()
        {
            //arrange
            Guid id = Guid.NewGuid();
            string gameName = "Yukon Ho!";
            int areaHeight = 6;
            int areaWidth = 12;
            int seed = 53;

            //act
            Game game = new Game()
            {
                Id = id,
                Name = gameName,
                GameAreaHeightInQuadrants = areaHeight,
                GameAreaWidthInQuadrants = areaWidth,
                Seed = seed
            };
            var teamName = "My Team!";
            game.Teams.Add(new Team() {Name= teamName});
            var gameDto = game.ToDto();
            

            //assert
            Assert.AreEqual(game.Id, gameDto.Id, "IDs differed");
            Assert.AreEqual(game.Name, gameDto.Name, "The name differed");
            Assert.AreEqual(game.GameAreaHeightInQuadrants, gameDto.GameAreaHeightInQuadrants, "The height differed");
            Assert.AreEqual(game.GameAreaWidthInQuadrants, gameDto.GameAreaWidthInQuadrants, "The width differed");
            Assert.AreEqual(game.Teams.First().Name, gameDto.TeamNames.First(), "The team name differed");

        }

        [Test]
        public void TeamConverterToDto()
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


            var teamDto = team.ToDto();
            //assert
            Assert.AreEqual(id, team.Id, "The ID differed");
            Assert.AreEqual(teamName, team.Name, "The name differed");
            Assert.AreEqual(accountBalance, team.AccountBalance, "The account balance differed");
            Assert.AreEqual(q1.X, team.KnownQuadrants[0].X, "The quadrant differed");

        }

        [Test]
        public void QuadrantConverterToDto()
        {
            //arrange
            int x =5;
            int y = 8;
            int content = 42;


            //act
            Quadrant q1 = new Quadrant() { X = x, Y = y, Content = content };
            var quadrantDto = q1.ToDto();
            //assert
            Assert.AreEqual(x, quadrantDto.X, "The X differed");
            Assert.AreEqual(y, quadrantDto.Y, "The Y differed");
            Assert.AreEqual(content, quadrantDto.Content, "The content differed");

        }
    }
}