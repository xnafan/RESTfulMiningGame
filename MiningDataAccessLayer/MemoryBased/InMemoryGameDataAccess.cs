using GenericDataAccessClassLibrary;
using GenericDataAccessClassLibrary.Interfaces.Generic;
using MiningDataAccessLayer.Model;
using System;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryGameDataAccess : GuidDataAccess<Game>, IGameDataAccess
    {
    }
}