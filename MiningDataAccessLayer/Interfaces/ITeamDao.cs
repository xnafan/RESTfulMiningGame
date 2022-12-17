using GenericDaoLibrary.Interfaces;
using MiningDataAccessLayer.Model;
using System;

namespace MiningDataAccessLayer.Interfaces
{
    public interface ITeamDao : IGenericDao<Team, Guid> {  }
}