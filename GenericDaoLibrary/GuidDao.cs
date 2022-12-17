using GenericDaoLibrary.Interfaces;
using System;

namespace GenericDaoLibrary
{
    public class GuidDao<T> : DaoBase<T, Guid> where T : IIdentifiable<Guid>
    {
        protected override Guid GetNewId() => Guid.NewGuid();
    }
}