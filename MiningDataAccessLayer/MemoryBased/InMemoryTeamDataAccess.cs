using GenericDataAccessClassLibrary;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
using System;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryTeamDataAccess : GuidDataAccess<Team>, ITeamDataAccess  { }
}