using System.Collections.Generic;

namespace Commander.IRepository
{
    public interface IRepositoryBase<T> where T:class,new()
    {
        IEnumerable<T> GetEntities();

        T GetEntity(int id);

        void CreateCommand(T entity);

        void UpdatedCommand(T entity);

        void DeleteCommand(T entity);
        bool SaveChanges();
    }
}