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
        Task<bool> AddPollRelated(PersonVM editPerson);

        /// <summary>
        /// Updates Crm information about specific voter based on the user of type VoterDetailsVM
        /// </summary>
        /// <param name="model"></param>
        /// <returns>True or False</returns>
        Task<bool> UpdateCrmRelatedAsync(VoterDetailsVM model);

        /// <summary>
        /// Updates voters specific reason based on their inputed reason and specified userId
        /// </summary>
        /// <param name="demand"></param>
        /// <param name="userId"></param>
        /// <returns>True or False</returns>
        Task<bool> updateSpecificReasonAsync(string reason, string userId);
        /// <summary>
        /// Updates voters specific demand based on their inputed demand and specified userId
        /// </summary>
        /// <param name="demand"></param>
        /// <param name="userId"></param>
        /// <returns>True or False</returns>
        Task<bool> updateSpecificDemandAsync(string demand, string userId);
    }
}
