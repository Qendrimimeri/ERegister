using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IMunicipalityRepository:IRepository<Municipality>
    {
        Task<Municipality> GetByName(string name);

        Task<int> GetMuniNameByUserIdAsync(string Id);
    }
}
