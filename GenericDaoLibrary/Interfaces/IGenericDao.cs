using System.Collections.Generic;
namespace GenericDaoLibrary.Interfaces;
public interface IGenericDao<T, Id> where T : IIdentifiable<Id>
{
    public IEnumerable<T> GetAll();
    public T GetById(Id idOfItemToRetrieve);
    public Id Add(T itemToAdd);
    public bool Delete(Id idOfItemToDelete);
    public bool Update(T itemToUpdate);
}