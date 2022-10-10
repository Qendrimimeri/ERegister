using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
                PoliticialSubjectId = (editPerson.CurrentVoter == null ? pollId.PoliticialSubjectId : int.Parse(editPerson.CurrentVoter)),
                FamMembers =pollId.FamMembers,
                GeneralDemand=pollId.GeneralDemand,
                SpecificDemand=pollId.SpecificDemand,
                GeneralReason=pollId.GeneralReason,
                SpecificReason=pollId.SpecificReason,
                HelpId=pollId.HelpId,
                Date = DateTime.Now,
                GeneralDescription=editPerson.GeneralDescription
            };

             _db.PollRelateds.Add(pollRelated);
             _db.SaveChanges();


            var getUser = await _appUser.FindUserByIdAsync(pollRelated.UserId);
            getUser.ActualStatus = (editPerson.ActualStatus == null? getUser.ActualStatus : editPerson.ActualStatus);
            var res = await _appUser.UpdateUserAsync(getUser);
            return true;

        }
        public async Task<bool> UpdateCrmRelatedAsync(VoterDetailsVM model)
        {
            var random = new Random();
            var helpId = Enumerable.Range(1, 2000000).OrderBy(x => random.Next()).Take(6).First();

            var helpTable = new Help()
            {
                Id = helpId,
                CanYouManage = (model.CanYouManage == 1 ? true : false),
                ActivitiesYouPlan = model.ActivitiesYourPlan,
                NeedHelp = (model.NeedHelp == 1 ? true : false)
            };

            await _db.Helps.AddAsync(helpTable);
            await _db.SaveChangesAsync();

            var res = await _db.PollRelateds.Where(x => x.UserId == model.Id).OrderByDescending(x => x.Date).FirstOrDefaultAsync();

            res.GeneralDemand = model.GeneralDemands;
            res.GeneralReason = model.GeneralReason;
            res.GeneralDescription = model.GeneralDescription;
            res.HelpId = helpId;
            await _db.SaveChangesAsync();
            return true;
        }

        //public async Task<bool>EditPollRelated(PersonVM editPerson)
        //{
          

        //}
        public void Save()
        {
            _db.SaveChanges();
        }
        
    }
}
