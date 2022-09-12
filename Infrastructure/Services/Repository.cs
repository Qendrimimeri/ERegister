using System.Linq.Expressions;
using Domain.Data;
using Domain.Data.Entities;
using ERegister.Application.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        
        protected readonly ApplicationDbContext _context;
        protected readonly ILogger _logger;
        protected DbSet<T> DbSet { get; set; }

        public Repository(ApplicationDbContext context , ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(T entity) => _context.Set<T>().AddAsync(entity);

        public void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRangeAsync(entities);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void DeleteRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public T GetById(int id) => _context.Set<T>().Find(id);

        public T GetByName(string name) => _context.Set<T>().Find(name);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
