using System.Collections.Generic;
using System.Linq;
using Commander.IRepository;
using Commander.Models;

namespace Commander.Repository
{
    public abstract class RepositoryBase : IRepositoryBase<BaseEntity>
    {
        public virtual void CreateCommand(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void DeleteCommand(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BaseEntity> GetEntities()
        {
            return MockData();
        }

        public BaseEntity GetEntity(int id)
        {
            var result = MockData();
            return result.FirstOrDefault(p=>p.ID == id);
        }

        public virtual bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public virtual void UpdatedCommand(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected abstract IEnumerable<BaseEntity> MockData();
        
    }
}