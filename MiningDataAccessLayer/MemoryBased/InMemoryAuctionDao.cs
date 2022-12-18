using GenericDaoLibrary;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;

namespace MiningDataAccessLayer.MemoryBased;
public class InMemoryAuctionDao : IntDao<Auction>, IAuctionDao{}