using GenericDataAccessClassLibrary;
using MiningClassLibrary;
using MiningDataAccessLayer.Interfaces;

namespace MiningDataAccessLayer.MemoryBased
{
    public class InMemoryAuctionDataAccess : GuidDataAccess<Auction> , IAuctionDataAccess { }
}