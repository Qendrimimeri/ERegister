using Domain.Data.Entities;

namespace Application.Repository.IRepository
{
    public interface IMunicipalityRepository:IRepository<Municipality>
    {
        /// <summary>
        /// Gets the municipality name based on specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Municipality name</returns>
        Task<Municipality> GetByName(string name);


        /// <summary>
        /// Gets the municipality of the user based on specified user id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Municipality</returns>
        Task<Municipality> GetMuniOfUser(string Id);

        /// <summary>
        /// Gets a list of Municipalities 
        /// </summary>
        /// <returns>List of type Municipality</returns>
        Task<List<Municipality>> GetAllMunicipalityAsync();
        
        
        /// <summary>
        /// Gets the name of municipality based on specified userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns the name of Municipality</returns>
        Task<string> GetMuniName(string userId);
    }
}
