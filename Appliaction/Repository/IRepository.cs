using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERegister.Application.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T GetByName(string name);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
