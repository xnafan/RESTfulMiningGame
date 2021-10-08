using System.Linq;
using System.Reflection;

namespace GenericDataAccessClassLibrary
{
    public static class ExtensionMethods
    {
        public static T CopyPropertiesTo<T>(this object sourceObject, T destinationObject)
        {
            foreach (PropertyInfo property in destinationObject.GetType().GetProperties().Where(p => p.CanWrite))
            {
                property.SetValue(destinationObject, property.GetValue(sourceObject, null), null);
            }
            return destinationObject;
        }
    }
}