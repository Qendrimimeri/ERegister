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
        /// <summary>
        /// Adds a new pollRelated for a specified user of type PersonVM
        /// </summary>
        /// <param name="editPerson"></param>
        /// <returns>True or False</returns>
        Task<bool> AddPollRelated(VoterVM editPerson);

        /// <summary>
        /// Updates Crm information about specific voter based on the user of type VoterDetailsVM
        /// </summary>
        /// <param name="model"></param>
        /// <returns>True or False</returns>
        Task<bool> UpdateCrmRelatedAsync(VoterDetailsVM model);

    }
}
