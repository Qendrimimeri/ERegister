using System.Linq.Expressions;
using Domain.Data;
using Domain.Data.Entities;
using ERegister.Application.Repository;

namespace Infrastructure.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity) => _context.Set<TEntity>().AddAsync(entity);

        public void AddRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().AddRangeAsync(entities);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Where(expression);

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();

        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id);

        public TEntity GetByName(string name) => _context.Set<TEntity>().Find(name);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
    }
}
