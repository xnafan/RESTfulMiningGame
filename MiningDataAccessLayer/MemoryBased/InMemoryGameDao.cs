using GenericDaoLibrary;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
using System;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryGameDao : ShortUidDao<MiningGame>, IMiningGameDao
    {
        public InMemoryGameDao()
        {
            CreateGames(10);
        }

        private void CreateGames(int amountToCreate)
        {
            for (int i = 0; i < amountToCreate; i++)
            {
                Add(new MiningGame("", $"Game {amountToCreate}" + DateTime.Now.ToString("hh:mm")));
            }
        }
    }
}