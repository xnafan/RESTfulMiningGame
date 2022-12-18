using GenericDaoLibrary;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
namespace MiningDataAccessLayer.MemoryBased;
public class InMemoryGameDao : ShortUidDao<MiningGame>, IMiningGameDao {}