using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningClassLibrary
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AccountBalance { get; set; }
        public IEnumerable<Guid> Maps = new List<Guid>();
    }
}