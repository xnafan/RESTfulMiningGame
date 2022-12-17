using GenericDaoLibrary.Interfaces;
using System.Collections.Generic;

namespace MiningDataAccessLayer.Model
{
    public class MiningGame : IIdentifiable<string>
    {
        public string Id { get; set; } = ShortUIDTool.CreateShortId();
        public string Name { get; set; }
        public List<Team> Teams { get; set; } = new();
        public int MapRowCount { get; set; }
        public int MapColumnCount { get; set; }
        public int Seed { get; set; }
    }
}