using System.Collections.Generic;

namespace Commander.IRepository
{
    public interface IRepositoryBase<T> where T:class
    {
        IEnumerable<T> GetEntities();

        T GetEntity(int id);
    }
}