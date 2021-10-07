using System.Collections.Generic;

namespace GenericDataAccessClassLibrary.Interfaces.Generic
{
    public interface IDataAccess<T, U> where T : IIdentifiable<U> 
    {
        public IEnumerable<T> GetAll();
        public T GetById(U idOfItemToRetrieve);
        public U Add(T itemToAdd);
        public bool Delete(U idOfItemToDelete);
        public bool Update(T itemToUpdate);
    }
}