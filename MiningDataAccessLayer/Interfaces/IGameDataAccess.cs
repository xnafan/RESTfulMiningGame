
using GenericDataAccessClassLibrary.Interfaces.Generic;
using MiningClassLibrary;
using System;

namespace MiningDataAccessLayer
{
    public interface IGameDataAccess : IDataAccess<Game, Guid> { }
}