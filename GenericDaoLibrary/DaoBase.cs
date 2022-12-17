using GenericDaoLibrary.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace GenericDaoLibrary;
public abstract class DaoBase<T, U> : IGenericDao<T, U> where T : IIdentifiable<U> where U : notnull
{
    private Dictionary<U, T> _internalStorage = new Dictionary<U, T>();
    public U Add(T itemToAdd)
    {
        var newId = GetNewId();
        while (_internalStorage.ContainsKey(newId))
        {
            newId = GetNewId();
        }
        itemToAdd.Id = newId;
        _internalStorage[itemToAdd.Id] = itemToAdd;
        return itemToAdd.Id;
    }

    public bool Delete(U idOfItemToDelete) => _internalStorage.Remove(idOfItemToDelete);

    public IEnumerable<T> GetAll() => _internalStorage.Values.ToList();

    public T GetById(U idOfItemToRetrieve)
    {
        if(!_internalStorage.ContainsKey(idOfItemToRetrieve))
        { return default(T); }
        return _internalStorage[idOfItemToRetrieve];
    }

    public bool Update(T itemToUpdate)
    {
        if (!_internalStorage.ContainsKey(itemToUpdate.Id)) { return false; }

        T existingItem = GetById(itemToUpdate.Id);
        CopyValues(itemToUpdate, existingItem);
        return true;
    }

    protected static void CopyValues(T sourceObject, T destinationObject)
    {
        sourceObject.CopyPropertiesTo(destinationObject);
    }
    protected abstract U GetNewId();
}