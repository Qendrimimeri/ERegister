using Application.ViewModels;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IPollRelatedRepository : IRepository<PollRelated>
    {
        Task<bool> AddPollRelated(PersonVM editPerson);

        Task<bool> UpdateCrmRelatedAsync(VoterDetailsVM model);

        Task<bool> updateSpecificReasonAsync(string demand, string userId);
    }
}
