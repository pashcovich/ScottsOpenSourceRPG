using System;

namespace Engine.Services.Interfaces
{
    public interface IPersistenceManager<T>
    {
        T LoadByID(Guid id);
        void Save(T entity);
    }
}
