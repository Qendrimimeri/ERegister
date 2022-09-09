using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Village
    {
        public Village()
        {
            Addresses = new HashSet<Address>();
            Kqzregisters = new HashSet<Kqzregister>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MunicipalityId { get; set; }

        public virtual Municipality? Municipality { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Kqzregister> Kqzregisters { get; set; }
    }
}
