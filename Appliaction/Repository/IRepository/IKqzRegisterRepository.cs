using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IKqzRegisterRepository :IRepository<Kqzregister>
    {

        /// <summary>
        /// Updates KqzResult based on specified KqzRegister model
        /// </summary>
        /// <param name="kqz"></param>
        /// <returns>KqzRegister result</returns>
        Task<Kqzregister> UpdateKqzAsync(Kqzregister kqz);

    }
}
