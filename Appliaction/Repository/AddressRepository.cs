using Application.Repository.IRepository;
using Domain.Data;
using Domain.Data.Entities;

namespace Application.Repository;

public class AddressRepository:Repository<Address>,IAddressRepository
    {
        private readonly ApplicationDbContext _db;

        public AddressRepository(ApplicationDbContext db ):base(db)
        {
            _db = db;
        }

    }
