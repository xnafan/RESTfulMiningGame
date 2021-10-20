
using GenericDataAccessClassLibrary.Interfaces.Generic;
using MiningDataAccessLayer.Model;
using System;

namespace MiningDataAccessLayer
{
    public interface IGameDataAccess : IDataAccess<Game, Guid> { }
}