using Application.ViewModels;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IBlockRepository:IRepository<Block>
    {
        Task<Block> GetByMunicipalityAsync(int id);

        Task AddAsync(AddBlockVM model);
    }
}
