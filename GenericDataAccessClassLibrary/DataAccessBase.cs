using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataAccessClassLibrary
{
    public abstract class DataAccessBase<T, U> : IDataAccess<T, U> where T : IIdentifiable<U> where U : notnull
    {

        private Dictionary<U, T> _internalStorage = new Dictionary<U, T>();

        public U Add(T itemToAdd)
        {
            itemToAdd.Id = GetNewId();
            _internalStorage[itemToAdd.Id] = itemToAdd;
            return itemToAdd.Id;
        }

        public bool Delete(U id)
        {
            return _internalStorage.Remove(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _internalStorage.Values.ToList();
        }

        public T GetById(U id)
        {
            return _internalStorage[id];
        }

        public bool Update(T updatedItem)
        {
            if (!_internalStorage.ContainsKey(updatedItem.Id)) { return false; }

            T existingItem = GetById(updatedItem.Id);
            if (existingItem == null) { return false; }
            CopyValues(updatedItem, existingItem);
            return true;
        }

        protected static void CopyValues(T sourceObject, T destinationObject)
        {
            sourceObject.CopyPropertiesTo(destinationObject);
        }

        protected abstract U GetNewId();
    }
}