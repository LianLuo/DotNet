using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Repository
{
    public class SqlCommandRepo : RepositoryBase
    {
        private readonly CommandContext _context;

        public SqlCommandRepo(CommandContext context)
        {
            _context = context;
        }
        protected override IEnumerable<BaseEntity> MockData()
        {
            return this._context.Commands;
        }

        public override bool SaveChanges()
        {
            return this._context.SaveChanges() > 0;
        }

        public override void CreateCommand(BaseEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            this._context.Commands.Add(entity as Command);
        }

        public override void UpdatedCommand(BaseEntity entity)
        {
            //Nothing
        }

        public override void DeleteCommand(BaseEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            this._context.Commands.Remove(entity as Command);
        }
    }
}