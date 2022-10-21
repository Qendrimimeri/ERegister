﻿using Application.Models;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IPoliticalSubjectRepository: IRepository<PoliticalSubject>
    {
        Task<IEnumerable<PoliticalSubject>> GetPoliticalSubjectsAsync();

        Task AddAsync(NameModel model);

        Task<PoliticalSubject> GetByNameAsync(string name);
    }
}
