using GenericDaoLibrary.Interfaces;

namespace GenericDaoLibrary
{
    public class ShortUidDao<T> : DaoBase<T, string> where T : IIdentifiable<string>
    {
        protected override string GetNewId() => ShortUIDTool.CreateShortId();
    }
}