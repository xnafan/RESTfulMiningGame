﻿using GenericDaoLibrary;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
using System;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryTeamDataAccess : GuidDao<Team>, ITeamDao  { }
}