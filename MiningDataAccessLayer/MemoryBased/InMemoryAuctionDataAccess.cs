using GenericDaoLibrary;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
namespace MiningDataAccessLayer.MemoryBased;
public class InMemoryAuctionDataAccess : IntDataAccess<Auction> , IMapSquareDao { }