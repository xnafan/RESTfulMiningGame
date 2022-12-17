using MiningApi.DTOs.Converters;
using MiningDataAccessLayer;
using MiningDataAccessLayer.Extensions;
using MiningDataAccessLayer.Model;
using NUnit.Framework;
using System;

namespace TestProject;

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
        string shortUid = ShortUIDTool.CreateShortId();
        string gameName = "Yukon Ho!";

        //act
        MiningGame game = new MiningGame(shortUid, gameName);
        var teamName = "My Team!";
        game.Teams.Add(new Team() {Name= teamName});
        var gameDto = game.ToDto();
        

        //assert
        Assert.AreEqual(game.Id, gameDto.Id, "IDs differed");
        Assert.AreEqual(game.Name, gameDto.Name, "The name differed");
        Assert.AreEqual(game.MapSideLength, gameDto.MapSideLength, "The height differed");
        //Assert.AreEqual(Teams.First().Name, gameDto.TeamNames.First(), "The team name differed");
        Console.WriteLine(game.ToAscii());
        Console.WriteLine(game);
    }

    [Test]
    public void TeamConverterToDto()
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


        var teamDto = team.ToDto();
        //assert
        Assert.AreEqual(id, team.Id, "The ID differed");
        Assert.AreEqual(teamName, team.Name, "The name differed");
        Assert.AreEqual(accountBalance, team.AccountBalance, "The account balance differed");
        Assert.AreEqual(q1.X, team.KnownMapSquares[0].X, "The quadrant differed");
    }

    [Test]
    public void MapSquareConverterToDto()
    {
        //arrange
        int x =5;
        int y = 8;
        int value = 42;

        //act
        MapSquare q1 = new MapSquare() { X = x, Y = y, Value = value };
        var quadrantDto = q1.ToDto();
        //assert
        Assert.AreEqual(x, quadrantDto.X, "The X differed");
        Assert.AreEqual(y, quadrantDto.Y, "The Y differed");
        Assert.AreEqual(value, quadrantDto.Value, "The content differed");
    }
}