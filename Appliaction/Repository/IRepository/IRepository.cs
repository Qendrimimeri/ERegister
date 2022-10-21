using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IRepository<T> where T : class    
    {
        /// <summary>
        /// Gets the first or the default value of specified entity
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Gets a generic collection of specified type of entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Adds new data for a specified type of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Add(T entity);
        /// <summary>
        /// Removes specific data for a specified type of entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Removes specified range for a specific type of entity
        /// </summary>
        /// <param name="entity"></param>
        void RemoveRange(IEnumerable<T> entity);

        /// <summary>
        /// Updates data for a specific entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Saves Changes for a generic type of collection of a specific entity
        /// </summary>
        /// <param name="entities"></param>
        void SaveChanges(IEnumerable<T> entities);
        
        
        
    }
}
