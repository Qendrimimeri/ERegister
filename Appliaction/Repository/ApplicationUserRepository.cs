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

        public async Task<List<PersonVM>> GetPersonInfoAsync()
        {
            var getAllUsers = await _db.Users.Select(person => new PersonVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                MunicipalityName =person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterName,
                VotersNumber=person.PollRelateds.Where(x=>x.UserId==person.Id).FirstOrDefault().FamMembers,
                PreviousVoter=person.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                InitialChances=person.PollRelateds.Where(x=>x.UserId==person.Id).FirstOrDefault().SuccessChances,
                ActualStatus=person.ActualStatus


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

        public async Task<ApplicationUser> GetUserByNameAsync(string name) 
            => await _userManager.FindByNameAsync(name);

        public async Task<PersonVM>GetUserByIdAsync(string id)
        {
            var getUser =  await _db.Users.Select(person => new PersonVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterName,
                VotersNumber = person.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                PreviousVoter = person.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                InitialChances = person.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().SuccessChances,
                ActualStatus = person.ActualStatus


            }).Where(x => x.Id == id).FirstOrDefaultAsync();

            return getUser;
        }
         

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task<IdentityResult> AddUserAsync(ApplicationUser user)
        {
            var res = await _userManager.CreateAsync(user);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            var res = await _userManager.UpdateAsync(user);
            await _db.SaveChangesAsync();
            return res;
        }
    }
}
