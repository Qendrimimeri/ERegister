using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Addresses
    {
        public int Id { get; set; }

        public int? MunicipalityId { get; set; }

        public int? VillageId { get; set; }

        public int? NeigborhoodId { get; set; }

        public int? HouseId { get; set; }

        public int? StreetId { get; set; }

        public int? PollCenterId { get; set; }


        // Navigation Properties
        public Municipalities? Municipalities { get; set; }
        public Vilages? Vilages { get; set; }
        public Neigborhoods? Neigborhoods { get; set; }
        public Houses? Houses { get; set; }
        public Streets? Streets { get; set; }
        public PollCenters? PollCenters { get; set; }
        public ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
