using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<PersonVM>> GetPersonInfoAsync()
        {
            var getAllUsers = await _db.Users.Select(person => new PersonVM()
            {
                Id = person.Id,
                Name = person.FullName,
                Village = person.Address.Village.Name,
                City = person.Address.Municipality.Name,
                FamMembers = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers
            }).ToListAsync();

            var usersInRole = await _userManager.GetUsersInRoleAsync("SimpleRole");

            var result = new List<PersonVM>();
            foreach (var user in getAllUsers)
            {
                foreach (var item in usersInRole)
                {
                    if (user.Id == item.Id)
                        result.Add(user);
                }
            }

            return result;
        
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
