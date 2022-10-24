using Application.ViewModels;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IStreetRepository:IRepository<Street>
    {
        Task<Street> GetByVillageAsync(int id);

        Task AddByVillageAsync(AddStreetVM model);

        Task AddByNeiborgoodAsync(AddStreetVM model);

        Task<Street> GetByNeigborhoodAsync(int id);
    }
}
