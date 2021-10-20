using GenericDataAccessClassLibrary.Interfaces.Generic;
using MiningDataAccessLayer.Model;
using System;

namespace MiningDataAccessLayer.Interfaces
{
    public interface IAuctionDataAccess : IDataAccess<Auction, Guid> { }
}