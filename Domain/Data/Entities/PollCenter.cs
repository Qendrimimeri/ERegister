using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class PollCenter
    {
        public PollCenter()
        {
            Addresses = new HashSet<Address>();
            Kqzregisters = new HashSet<Kqzregister>();
        }

        public int Id { get; set; }
        public string? CenterNumber { get; set; }
        public string? CenterName { get; set; }
        public int? MunicipalitydId { get; set; }
        public int? VillageId { get; set; }
        public int? NeighborhoodId { get; set; }

        public virtual Neighborhood? Neighborhood { get; set; }
        public virtual Village? Village { get; set; }
        public virtual Municipality? Municipalityd { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Kqzregister> Kqzregisters { get; set; }
    }
}
