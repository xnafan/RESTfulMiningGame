using System;

namespace GenericDataAccessClassLibrary.Interfaces.Generic
{
    public interface IIdentifiable<T> where T : notnull
    {
        public T Id { get; set; }
    }
}