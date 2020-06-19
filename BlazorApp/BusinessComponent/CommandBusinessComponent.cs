using System.Collections.Generic;
using System.Linq;
using BlazorApp.Models;
using BlazorApp.Repository;

namespace BlazorApp.BusinessComponent
{
    public class CommandBusinessComponent : IBaseBusinessComponent<Commander>
    {
        private readonly BlazorContext _blazorContext;

        public CommandBusinessComponent(BlazorContext blazorContext)
        {
            _blazorContext = blazorContext;
        }

        public void AddEntity(Commander entity)
        {
            this._blazorContext.Commanders.Add(entity);
        }

        public void DeleteEntity(Commander entity)
        {
            this._blazorContext.Commanders.Remove(entity);
        }

        public IEnumerable<Commander> GetAllEntities()
        {
            return this._blazorContext.Commanders.ToList();
        }

        public Commander GetEntityById(int ID)
        {
            return this._blazorContext.Commanders.FirstOrDefault(p=>p.ID == ID);
        }

        public bool SaveChanges()
        {
            return this._blazorContext.SaveChanges() > 0;
        }

        public void UpdateEntity(Commander entity)
        {
            // do nothing.
        }
    }
}