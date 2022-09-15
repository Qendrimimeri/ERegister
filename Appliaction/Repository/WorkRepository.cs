﻿using Application.Repository.IRepository;
using Domain.Data;
using Domain.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        private readonly ApplicationDbContext _db;

        public WorkRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}