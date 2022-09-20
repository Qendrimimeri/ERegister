using Application.Repository.IRepository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ILogger logger;
        private UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Repository( ApplicationDbContext db, 
                           ILogger logger, 
                           UserManager<ApplicationUser> userManager, 
                           SignInManager<ApplicationUser> signInManager) : this(db)
        {
            this.logger = logger;
            this.userManager = userManager;
            _signInManager = signInManager;
            this.db = db; 
        }

        public async Task Add(T entity) 
            => await db.Set<T>().AddAsync(entity);

        public async Task<IEnumerable<T>> GetAll() 
            => db.Set<T>().ToList();

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter) 
            => await db.Set<T>().Where(filter).FirstOrDefaultAsync();

        public void Remove(T entity) => db.Set<T>().Remove(entity);
        public void Update(T entity) => db.Set<T>().Update(entity);


        public void RemoveRange(IEnumerable<T> entity) => db.Set<T>().RemoveRange(entity);

        public void SaveChanges(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
