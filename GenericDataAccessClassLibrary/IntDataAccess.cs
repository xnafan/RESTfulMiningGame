using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;

namespace GenericDataAccessClassLibrary
{
    public class IntDataAccess<T> : DataAccessBase<T, int> where T : IIdentifiable<int>
    {
        int _nextId;            
        protected override int GetNewId()
        {
            _nextId++;
            return _nextId;
        }
    }
}