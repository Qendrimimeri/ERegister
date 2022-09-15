using Application.Repository.IRepository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ApplicationUserRepository:Repository<ApplicationUser>,IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepository(ApplicationDbContext db, 
                                         UserManager<ApplicationUser> userManager) : base(db)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync()
            => await _userManager.GetUsersInRoleAsync("SimpleRole");

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
