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
            var AllUsers = await _db.Users.Select(person => new PersonVM()
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

            var list = new List<PersonVM>();
            foreach (var user in AllUsers)
            {
                foreach (var item in usersInRole)
                {
                    if (user.Id == item.Id)
                    {
                        list.Add(user);
                    }
                }
            }

            return list;
        
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
