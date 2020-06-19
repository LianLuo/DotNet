using System.Collections.Generic;
using BlazorApp.Models;

namespace BlazorApp.BusinessComponent
{
    
    public interface IBaseBusinessComponent<T> where T: BaseEntity
    {
        /// <summary>
        /// add entity
        /// </summary>
        void AddEntity(T entity);
        /// <summary>
        /// update entity
        /// </summary>
        void UpdateEntity(T entity);
        /// <summary>
        /// delete entity
        /// </summary>
        void DeleteEntity(T entity);
        /// <summary>
        /// fetch entity by id
        /// </summary>
        T GetEntityById(int ID);
        /// <summary>
        /// fetch all entity
        /// </summary>
        IEnumerable<T> GetAllEntities();
        bool SaveChanges();
    }
}