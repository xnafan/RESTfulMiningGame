using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.MemoryBased;
using MiningDataAccessLayer.Model;
using System;
using System.Diagnostics;
namespace MiningDataAccessLayer;
public static class TestDataCreator
{

    public static IMiningGameDao MiningGameDao { get; set; } = new InMemoryGameDao();
    public static ITeamDao TeamDao { get; set; } = new InMemoryTeamDao();
    public static IAuctionDao AuctionDao { get; set; } = new InMemoryAuctionDao();

    static TestDataCreator()
    {
        GenerateRandomData();
    }
    private static void GenerateRandomData()
    {
        int minAmountOfGames = 3, maxAmountOfGames = 10;
        Random rnd = new Random();

        for (int i = 0; i < minAmountOfGames + rnd.Next(maxAmountOfGames - minAmountOfGames); i++)
        {
            var game = new MiningGame() { Name = $"Game {i + 1}" };
            MiningGameDao.Add(game);
            Debug.WriteLine("Game: " + game.Id);
            var numberOfTeams = rnd.Next(5) + 3;
            for (int teamCounter = 0; teamCounter < numberOfTeams; teamCounter++)
            {
                var team = new Team() { Name = $"Team {teamCounter}" };
                team.AccountBalance = game.InitialTeamAccountBalance;
                game.Teams.Add(team);
                TeamDao.Add(team);
                Debug.WriteLine("\t team:" + team.Id + "\t");
            }
        }
    }
}
