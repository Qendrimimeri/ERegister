using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class PollCenter
    {
        public PollCenter()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string? CenterNumber { get; set; }
        public string? CenterName { get; set; }
        public int? MunicipalitydId { get; set; }

        public virtual Municipality? Municipalityd { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
