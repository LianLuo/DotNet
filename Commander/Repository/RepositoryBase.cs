using System.Collections.Generic;
using System.Linq;
using Commander.IRepository;
using Commander.Models;

namespace Commander.Repository
{
    public abstract class RepositoryBase : IRepositoryBase<BaseEntity>
    {
        public IEnumerable<BaseEntity> GetEntities()
        {
            return MockData();
        }

        public BaseEntity GetEntity(int id)
        {
            var result = MockData();
            return result.Where(p=>p.ID == id).FirstOrDefault();
        }

        protected abstract IEnumerable<BaseEntity> MockData();
        
    }
}