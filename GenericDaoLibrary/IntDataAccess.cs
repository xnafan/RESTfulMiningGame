using GenericDaoLibrary.Interfaces;
using System;

namespace GenericDaoLibrary
{
    public class IntDataAccess<T> : DaoBase<T, int> where T : IIdentifiable<int>
    {
        int _nextId;            
        protected override int GetNewId()
        {
            _nextId++;
            return _nextId;
        }
    }
}