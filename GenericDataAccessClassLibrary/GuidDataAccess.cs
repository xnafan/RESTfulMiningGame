using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;

namespace GenericDataAccessClassLibrary
{
    public class GuidDataAccess<T> : DataAccessBase<T, Guid> where T : IIdentifiable<Guid>
    {
        protected override Guid GetNewId() => Guid.NewGuid();
    }
}