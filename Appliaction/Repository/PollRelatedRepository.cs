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

        public async Task<bool> AddPollRelated(VoterVM editPerson)
        {
            var pollId =  _db.PollRelateds.Where(x => x.VoterId == editPerson.Id).FirstOrDefault();
            var pollRelated = new PollRelated()
            {
                VoterId = editPerson.Id,
                SuccessChances = editPerson.ActualChances,
                PoliticialSubjectId = (editPerson.CurrentVoter == null ? pollId.PoliticialSubjectId : int.Parse(editPerson.CurrentVoter)),
                FamMembers =pollId.FamMembers,
                Demand=pollId.Demand,
                Reason=pollId.Reason,
                HelpId=pollId.HelpId,
                Date = DateTime.Now,
                Description=editPerson.Description
            };

             _db.PollRelateds.Add(pollRelated);

            var getUser = await _db.Voters.Where(x => x.Id == editPerson.Id).FirstOrDefaultAsync();
            getUser.ActualStatus = (editPerson.ActualStatus ?? getUser.ActualStatus);
            await _db.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateCrmRelatedAsync(VoterDetailsVM model)
        {
            var helpId = _db.Helps.ToList().OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

            var helpTable = new Help()
            {
                Id = helpId,
                CanYouManage = (model.CanYouManage == 1 ? true : false),
                ActivitiesYouPlan = model.ActivitiesYourPlan,
                NeedHelp = (model.NeedHelp == 1 ? true : false)
            };

            await _db.Helps.AddAsync(helpTable);
            await _db.SaveChangesAsync();

            var res = await _db.PollRelateds.Where(x => x.VoterId == model.Id).OrderByDescending(x => x.Date).FirstOrDefaultAsync();

            res.Demand = (model.Demands == "shto" ? res.Demand : model.Demands);
            res.Reason = (model.Reason == "shto" ? res.Reason : model.Reason);
            res.Description = (model.Description == null ? res.Description : model.Description) ;
            res.HelpId = helpId;
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
