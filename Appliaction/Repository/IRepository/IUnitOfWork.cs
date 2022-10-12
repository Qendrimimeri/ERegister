using Application.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IAddressRepository Address { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IBlockRepository Block { get; }
        IHelpRepository Help{ get; }
        IKqzRegisterRepository KqzRegister { get; }
        IMunicipalityRepository Municipality { get; }
        INeighborhoodRepository Neighborhood { get; }
        IPoliticalSubjectRepository PoliticalSubject { get; }
        IPollCenterRepository PollCenter { get; }
        IPollRelatedRepository PollRelated { get; }
        IStreetRepository Street { get; }
        IVillageRepository Village { get; }
        IWorkRepository Work { get; }

        Task<int> Done();
        void SaveChanges();

      
    }
}
