using GenericDataAccessClassLibrary;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryAuctionDataAccess : GuidDataAccess<Auction> , IAuctionDataAccess { }
}