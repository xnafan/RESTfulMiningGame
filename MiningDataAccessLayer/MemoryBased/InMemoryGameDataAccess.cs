using GenericDataAccessClassLibrary;
using GenericDataAccessClassLibrary.Interfaces.Generic;
using MiningClassLibrary;
using System;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryGameDataAccess : GuidDataAccess<Game>, IGameDataAccess
    {
    }
}