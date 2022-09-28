﻿using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Neighborhood
    {
        public Neighborhood()
        {
            Addresses = new HashSet<Address>();
            Kqzregisters = new HashSet<Kqzregister>();
            Streets = new HashSet<Street>();
            PollCenters = new HashSet<PollCenter>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MunicipalityId { get; set; }
        public int? VillageId { get; set; }

        public virtual Village? Village { get; set; }
        public virtual Municipality? Municipality { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Kqzregister> Kqzregisters { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
        public virtual ICollection<PollCenter> PollCenters { get; set; }
    }
}
