using GenericDataAccessClassLibrary.Interfaces.Generic;
using MiningClassLibrary;
using System;

namespace MiningDataAccessLayer.Interfaces
{
    public interface ITeamDataAccess : IDataAccess<Team, Guid> {  }
}