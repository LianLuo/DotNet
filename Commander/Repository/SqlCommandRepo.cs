using System.Collections.Generic;
using Commander.IRepository;
using Commander.Models;

namespace Commander.Repository
{
    public class SqlCommandRepo : IRepositoryBase<Command>
    {
        public IEnumerable<Command> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Command GetEntity(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}