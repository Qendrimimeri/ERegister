using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PollRelatedRepository : Repository<PollRelated>, IPollRelatedRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IApplicationUserRepository _appUser;

        public PollRelatedRepository(ApplicationDbContext db,IApplicationUserRepository appUser) : base(db)
        {
            _db = db;
            _appUser = appUser;
        }


        public async Task<bool> AddPollRelated(PersonVM editPerson)
        {
            var pollId =  _db.PollRelateds.Where(x => x.UserId == editPerson.Id).FirstOrDefault();
            var pollRelated = new PollRelated()
            {
                UserId = editPerson.Id,
                SuccessChances = editPerson.ActualChances,
                PoliticialSubjectId = Int32.Parse(editPerson.CurrentVoter),
                FamMembers =pollId.FamMembers,
                GeneralDemand=pollId.GeneralDemand,
                SpecificDemand=pollId.SpecificDemand,
                GeneralReason=pollId.GeneralReason,
                SpecificReason=pollId.SpecificReason,
                HelpId=pollId.HelpId,
                Date = DateTime.Now,
            };
            await _db.PollRelateds.AddAsync(pollRelated);
            await _db.SaveChangesAsync();

            var getUser = _appUser.GetUserByIdAsync(pollRelated.UserId);
            var addUser= new ApplicationUser() { ActualStatus = editPerson.ActualStatus};
            await _appUser.UpdateUserAsync(addUser);
            return true;

        }
        public void Save()
        {
            _db.SaveChanges();
        }
        
    }
}
