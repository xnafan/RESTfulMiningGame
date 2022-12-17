using GenericDaoLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace MiningDataAccessLayer.Model
{
    public class Team : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AccountBalance { get; set; }
        public List<Quadrant> KnownQuadrants { get; set; } = new();
    }
}