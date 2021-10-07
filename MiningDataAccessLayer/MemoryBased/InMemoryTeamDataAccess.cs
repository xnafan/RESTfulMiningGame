using GenericDataAccessClassLibrary;
using GenericDataAccessClassLibrary.Interfaces.Generic;
using MiningClassLibrary;
using MiningDataAccessLayer.Interfaces;
using System;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryTeamDataAccess : GuidDataAccess<Team>, ITeamDataAccess  { }
}