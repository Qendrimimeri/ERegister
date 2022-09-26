using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Street
    {
        public Street()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MunicipalityId { get; set; }
        public string? StreetSource { get; set; }
        public int? VillageId { get; set; }
        public int? NeighborhoodId { get; set; }

        public virtual Village? Village { get; set; }
        public virtual Neighborhood? Neighborhood { get; set;}
        public virtual Municipality? Municipality { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
